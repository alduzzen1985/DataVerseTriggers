using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Newtonsoft.Json.Linq;

namespace Automation_Analyzer
{
    public class FlowIndexer
    {
        private readonly DatabaseManager _db;
        private readonly FlowRepository _flowRepository;
        private readonly WorkflowDataverseRepository _workflowRepository;
        private readonly MetadataRepository _metadataRepository;
        private readonly FlowTriggerParser _parser;
        private readonly ClassicWorkflowParser _classicParser;

        public FlowIndexer(
            DatabaseManager db,
            FlowRepository flowRepository,
            WorkflowDataverseRepository workflowRepository,
            MetadataRepository metadataRepository)
        {
            _db                 = db;
            _flowRepository     = flowRepository;
            _workflowRepository = workflowRepository;
            _metadataRepository = metadataRepository;
            _parser             = new FlowTriggerParser();
            _classicParser      = new ClassicWorkflowParser();
        }

        public async Task RebuildIndexAsync(string environmentId)
        {
            Console.WriteLine("Fetching entity metadata...");
            var entityMap = _metadataRepository.GetEntitySetToLogicalNameMap();
            Console.WriteLine(string.Format("  {0} entities loaded.", entityMap.Count));

            Console.WriteLine("Fetching Cloud Flows...");
            var cloudFlows = await _flowRepository.GetAllCloudFlowsAsync(environmentId);
            Console.WriteLine(string.Format("  Found {0} Cloud Flows.", cloudFlows.Count));

            foreach (var flow in cloudFlows)
            {
                try { await IndexCloudFlowAsync(flow, entityMap); }
                catch (Exception ex)
                { Console.WriteLine(string.Format("  [WARN] '{0}': {1}", flow.Name, ex.Message)); }
            }

            Console.WriteLine("Fetching Classic Workflows...");
            var classicWorkflows = _workflowRepository.GetAllClassicWorkflows();
            Console.WriteLine(string.Format("  Found {0} Classic Workflows.", classicWorkflows.Count));

            foreach (var wf in classicWorkflows)
            {
                try { await IndexClassicWorkflowAsync(wf); }
                catch (Exception ex)
                { Console.WriteLine(string.Format("  [WARN] '{0}': {1}", wf.Name, ex.Message)); }
            }

            Console.WriteLine("Computing dependency edges...");
            await ComputeAllDependenciesAsync();
        }

        public async Task SyncChangedFlowsAsync(string environmentId)
        {
            var entityMap    = _metadataRepository.GetEntitySetToLogicalNameMap();
            var lastSync     = await GetLastSyncTimeAsync();
            var changedFlows = await _flowRepository.GetFlowsModifiedAfterAsync(environmentId, lastSync);
            Console.WriteLine(string.Format("  {0} flows changed since {1}.", changedFlows.Count, lastSync));

            foreach (var flow in changedFlows)
            {
                DeleteAutomationFromIndex(flow.Id);
                try { await IndexCloudFlowAsync(flow, entityMap); }
                catch (Exception ex)
                { Console.WriteLine(string.Format("  [WARN] '{0}': {1}", flow.Name, ex.Message)); }
            }

            await RecomputeDependenciesForAsync(changedFlows.Select(f => f.Id));
        }

        private async Task IndexCloudFlowAsync(FlowRaw flow, Dictionary<string, string> entityMap)
        {
            var index = new FlowIndex
            {
                Id            = flow.Id,
                Name          = flow.Name,
                Category      = flow.Category,
                EnvironmentId = flow.EnvironmentId,
                LastModified  = flow.LastModified,
                LastIndexed   = DateTime.UtcNow,
                IsActive      = flow.IsActive
            };

            if (!string.IsNullOrWhiteSpace(flow.DefinitionJson))
            {
                try
                {
                    var definition = JObject.Parse(flow.DefinitionJson);
                    var condition  = _parser.GetTriggerCondition(flow.DefinitionJson);

                    index.Trigger = new FlowTriggerIndex
                    {
                        AutomationId        = flow.Id,
                        TriggerType         = condition.RawTriggerType,
                        EntityName          = ResolveEntityName(condition.EntityName, entityMap),
                        TriggersOnCreate    = condition.Operations.Contains(TriggerOperation.Create),
                        TriggersOnUpdate    = condition.Operations.Contains(TriggerOperation.Update),
                        TriggersOnDelete    = condition.Operations.Contains(TriggerOperation.Delete),
                        FilteringAttributes = condition.FilteringAttributes,
                        FilterExpression    = condition.FilterExpression
                    };

                    index.Actions = _parser.ExtractDataverseActions(definition);
                    foreach (var a in index.Actions)
                    {
                        a.AutomationId = flow.Id;
                        a.EntityName   = ResolveEntityName(a.EntityName, entityMap);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("  [WARN] Parsing '{0}': {1}", flow.Name, ex.Message));
                }
            }

            await SaveFlowIndexAsync(index);
        }

        private async Task IndexClassicWorkflowAsync(ClassicWorkflowRaw wf)
        {
            // Classic Workflow entity names come from Dataverse fields (primaryentity, EntityName
            // attribute in XAML) which already use the logical name — no conversion needed.
            var index = new FlowIndex
            {
                Id            = wf.Id,
                Name          = wf.Name,
                Category      = wf.Category,
                EnvironmentId = null,
                LastModified  = DateTime.MinValue,
                LastIndexed   = DateTime.UtcNow,
                IsActive      = wf.IsActive,
                Trigger       = _classicParser.ParseTrigger(wf),
                Actions       = _classicParser.ParseActions(wf)
            };

            await SaveFlowIndexAsync(index);
        }

        // Converts an OData collection name to its logical name.
        // Falls back to the raw value if not in the map (already a logical name, or unknown).
        private static string ResolveEntityName(string rawName, Dictionary<string, string> entityMap)
        {
            if (string.IsNullOrEmpty(rawName)) return rawName;
            string logicalName;
            return entityMap.TryGetValue(rawName, out logicalName) ? logicalName : rawName;
        }

        private Task SaveFlowIndexAsync(FlowIndex index)
        {
            return Task.Run(() =>
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        conn.Execute(
                            @"INSERT OR REPLACE INTO Automations
                              (Id, Name, Category, EnvironmentId, LastModified, LastIndexed, IsActive)
                              VALUES (@Id, @Name, @Category, @EnvironmentId, @LastModified, @LastIndexed, @IsActive)",
                            new { index.Id, index.Name, index.Category,
                                  index.EnvironmentId, index.LastModified, index.LastIndexed,
                                  IsActive = index.IsActive ? 1 : 0 }, tx);

                        // Save trigger (and its filtering-attribute child rows)
                        conn.Execute("DELETE FROM AutomationTriggerAttributes WHERE AutomationId = @Id",
                            new { index.Id }, tx);
                        conn.Execute("DELETE FROM AutomationTriggers WHERE AutomationId = @Id",
                            new { index.Id }, tx);

                        if (index.Trigger != null)
                        {
                            conn.Execute(
                                @"INSERT INTO AutomationTriggers
                                  (AutomationId, TriggerType, EntityName,
                                   TriggersOnCreate, TriggersOnUpdate, TriggersOnDelete,
                                   FilterExpression)
                                  VALUES (@AutomationId, @TriggerType, @EntityName,
                                          @TriggersOnCreate, @TriggersOnUpdate, @TriggersOnDelete,
                                          @FilterExpression)",
                                new
                                {
                                    AutomationId     = index.Trigger.AutomationId,
                                    index.Trigger.TriggerType,
                                    index.Trigger.EntityName,
                                    TriggersOnCreate = index.Trigger.TriggersOnCreate ? 1 : 0,
                                    TriggersOnUpdate = index.Trigger.TriggersOnUpdate ? 1 : 0,
                                    TriggersOnDelete = index.Trigger.TriggersOnDelete ? 1 : 0,
                                    index.Trigger.FilterExpression
                                }, tx);

                            foreach (var attr in index.Trigger.FilteringAttributes)
                            {
                                conn.Execute(
                                    @"INSERT INTO AutomationTriggerAttributes (AutomationId, AttributeName)
                                      VALUES (@AutomationId, @AttributeName)",
                                    new { AutomationId = index.Id, AttributeName = attr }, tx);
                            }
                        }

                        // Save actions (and their field child rows)
                        // Delete fields first, then actions (child before parent)
                        conn.Execute(@"
                            DELETE FROM AutomationActionFields
                            WHERE ActionId IN (
                                SELECT Id FROM AutomationActions WHERE AutomationId = @Id
                            )", new { index.Id }, tx);
                        conn.Execute("DELETE FROM AutomationActions WHERE AutomationId = @Id",
                            new { index.Id }, tx);

                        foreach (var action in index.Actions)
                        {
                            conn.Execute(
                                @"INSERT INTO AutomationActions
                                  (AutomationId, ActionName, ActionType, EntityName, Description)
                                  VALUES (@AutomationId, @ActionName, @ActionType, @EntityName, @Description)",
                                new
                                {
                                    AutomationId = action.AutomationId,
                                    action.ActionName,
                                    action.ActionType,
                                    action.EntityName,
                                    action.Description
                                }, tx);

                            if (action.Fields != null && action.Fields.Count > 0)
                            {
                                var actionId = conn.QueryFirstOrDefault<long>(
                                    "SELECT last_insert_rowid()", transaction: tx);
                                foreach (var field in action.Fields)
                                {
                                    conn.Execute(
                                        @"INSERT INTO AutomationActionFields (ActionId, FieldName)
                                          VALUES (@ActionId, @FieldName)",
                                        new { ActionId = actionId, FieldName = field }, tx);
                                }
                            }
                        }

                        tx.Commit();
                    }
                }
            });
        }

        private void DeleteAutomationFromIndex(string automationId)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                conn.Execute(
                    "DELETE FROM AutomationDependencies WHERE SourceAutomationId = @id OR TargetAutomationId = @id",
                    new { id = automationId });
                conn.Execute(@"
                    DELETE FROM AutomationActionFields
                    WHERE ActionId IN (
                        SELECT Id FROM AutomationActions WHERE AutomationId = @id
                    )", new { id = automationId });
                conn.Execute("DELETE FROM AutomationActions WHERE AutomationId = @id",
                    new { id = automationId });
                conn.Execute("DELETE FROM AutomationTriggerAttributes WHERE AutomationId = @id",
                    new { id = automationId });
                conn.Execute("DELETE FROM AutomationTriggers WHERE AutomationId = @id",
                    new { id = automationId });
                conn.Execute("DELETE FROM Automations WHERE Id = @id",
                    new { id = automationId });
            }
        }

        private Task ComputeAllDependenciesAsync()
        {
            return Task.Run(() =>
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    conn.Execute("DELETE FROM AutomationDependencies");
                    conn.Execute(@"
                        INSERT INTO AutomationDependencies
                            (SourceAutomationId, TargetAutomationId, MatchReason, Confidence)
                        SELECT DISTINCT
                            aa.AutomationId,
                            at.AutomationId,
                            aa.ActionType || ' on ' || aa.EntityName,
                            CASE
                                WHEN NOT EXISTS (
                                    SELECT 1 FROM AutomationTriggerAttributes ata
                                    WHERE ata.AutomationId = at.AutomationId
                                ) THEN 'Certain'
                                ELSE 'Possible'
                            END
                        FROM AutomationActions aa
                        JOIN AutomationTriggers at ON at.EntityName = aa.EntityName
                        WHERE aa.AutomationId != at.AutomationId
                          AND (
                            (at.TriggersOnCreate = 1 AND aa.ActionType = 'CreateRecord')
                            OR
                            (at.TriggersOnUpdate = 1 AND aa.ActionType = 'UpdateRecord')
                            OR
                            (at.TriggersOnDelete = 1 AND aa.ActionType = 'DeleteRecord')
                          )
                    ");
                }
            });
        }

        private Task RecomputeDependenciesForAsync(IEnumerable<string> automationIds)
        {
            return Task.Run(() =>
            {
                var ids = automationIds.ToList();
                if (!ids.Any()) return;

                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    foreach (var id in ids)
                        conn.Execute(
                            "DELETE FROM AutomationDependencies WHERE SourceAutomationId = @id OR TargetAutomationId = @id",
                            new { id });

                    conn.Execute(@"
                        INSERT INTO AutomationDependencies
                            (SourceAutomationId, TargetAutomationId, MatchReason, Confidence)
                        SELECT DISTINCT
                            aa.AutomationId,
                            at.AutomationId,
                            aa.ActionType || ' on ' || aa.EntityName,
                            CASE
                                WHEN NOT EXISTS (
                                    SELECT 1 FROM AutomationTriggerAttributes ata
                                    WHERE ata.AutomationId = at.AutomationId
                                ) THEN 'Certain'
                                ELSE 'Possible'
                            END
                        FROM AutomationActions aa
                        JOIN AutomationTriggers at ON at.EntityName = aa.EntityName
                        WHERE aa.AutomationId != at.AutomationId
                          AND (aa.AutomationId IN @ids OR at.AutomationId IN @ids)
                          AND (
                            (at.TriggersOnCreate = 1 AND aa.ActionType = 'CreateRecord')
                            OR
                            (at.TriggersOnUpdate = 1 AND aa.ActionType = 'UpdateRecord')
                            OR
                            (at.TriggersOnDelete = 1 AND aa.ActionType = 'DeleteRecord')
                          )
                    ", new { ids });
                }
            });
        }

        private Task<DateTime> GetLastSyncTimeAsync()
        {
            return Task.Run(() =>
            {
                using (var conn = _db.GetConnection())
                {
                    conn.Open();
                    var result = conn.QueryFirstOrDefault<DateTime?>(
                        "SELECT MAX(LastIndexed) FROM Automations WHERE Category = 5");
                    return result ?? DateTime.UtcNow.AddDays(-30);
                }
            });
        }
    }
}
