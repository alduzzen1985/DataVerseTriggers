using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Dapper;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json.Linq;

namespace DataVerseTrigger.Helper.TriggerDB
{
    public class TriggerIndexService
    {
        private readonly IOrganizationService _service;
        private readonly TriggerDatabaseManager _db;
        private Action<int, string> _report;

        private static readonly XNamespace _xamlNs = "http://schemas.microsoft.com/winfx/2006/xaml";
        private const int XamlBatchSize = 50;

        public TriggerIndexService(IOrganizationService service, TriggerDatabaseManager db)
        {
            _service = service;
            _db = db;
        }

        public void RebuildIndex(string environmentId, Action<int, string> reportProgress)
        {
            _report = reportProgress ?? ((p, m) => { });

            _report(5, "Fetching entity metadata...");
            var entityMap = GetEntitySetToLogicalNameMap();

            _report(10, "Fetching Cloud Flows...");
            var cloudFlows = FetchCloudFlows(environmentId);
            _report(15, $"Found {cloudFlows.Count} Cloud Flows. Indexing...");

            for (int i = 0; i < cloudFlows.Count; i++)
            {
                int pct = 15 + (int)(55.0 * i / Math.Max(cloudFlows.Count, 1));
                _report(pct, $"Indexing flow {i + 1}/{cloudFlows.Count}: {cloudFlows[i].Name}");
                try { SaveFlowIndex(BuildCloudFlowIndex(cloudFlows[i], entityMap)); }
                catch { }
            }

            _report(70, "Fetching Classic Workflows...");
            var workflows = FetchClassicWorkflows();
            _report(75, $"Found {workflows.Count} Classic Workflows. Indexing...");

            for (int i = 0; i < workflows.Count; i++)
            {
                int pct = 75 + (int)(15.0 * i / Math.Max(workflows.Count, 1));
                _report(pct, $"Indexing workflow {i + 1}/{workflows.Count}: {workflows[i].Name}");
                try { SaveFlowIndex(BuildClassicWorkflowIndex(workflows[i])); }
                catch { }
            }

            _report(90, "Computing dependencies...");
            ComputeDependencies();
            _report(100, "Done.");
        }

        #region Data fetching

        private Dictionary<string, string> GetEntitySetToLogicalNameMap()
        {
            var request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };
            var response = (RetrieveAllEntitiesResponse)_service.Execute(request);
            return response.EntityMetadata
                .Where(e => !string.IsNullOrEmpty(e.EntitySetName))
                .ToDictionary(
                    e => e.EntitySetName,
                    e => e.LogicalName,
                    StringComparer.OrdinalIgnoreCase);
        }

        private List<FlowRaw> FetchCloudFlows(string environmentId)
        {
            var query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet("workflowid", "workflowidunique", "name", "category", "modifiedon", "clientdata", "statecode"),
                PageInfo = new PagingInfo { Count = 5000, PageNumber = 1, ReturnTotalRecordCount = false }
            };
            query.Criteria.AddCondition("category", ConditionOperator.Equal, 5);
            query.Criteria.AddCondition("type", ConditionOperator.Equal, 1);

            var results = new List<FlowRaw>();
            EntityCollection response;
            do
            {
                response = _service.RetrieveMultiple(query);
                results.AddRange(response.Entities.Select(e => new FlowRaw
                {
                    Id = e.Id.ToString(),
                    UniqueId = e.Contains("workflowidunique")
                        ? e.GetAttributeValue<Guid>("workflowidunique").ToString()
                        : e.Id.ToString(),
                    Name = e.GetAttributeValue<string>("name"),
                    Category = e.GetAttributeValue<OptionSetValue>("category")?.Value ?? 5,
                    EnvironmentId = environmentId,
                    LastModified = e.GetAttributeValue<DateTime>("modifiedon"),
                    DefinitionJson = e.GetAttributeValue<string>("clientdata"),
                    IsActive = e.GetAttributeValue<OptionSetValue>("statecode")?.Value == 1
                }));
                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = response.PagingCookie;
            }
            while (response.MoreRecords);

            return results;
        }

        private List<ClassicWorkflowRaw> FetchClassicWorkflows()
        {
            var query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet(
                    "workflowid", "name", "category", "primaryentity",
                    "triggeroncreate", "triggerondelete",
                    "triggeronupdateattributelist", "statecode"),
                PageInfo = new PagingInfo { Count = 5000, PageNumber = 1, ReturnTotalRecordCount = false }
            };
            query.Criteria.AddCondition("category", ConditionOperator.Equal, 0);
            query.Criteria.AddCondition("type", ConditionOperator.Equal, 1);

            var workflows = new List<ClassicWorkflowRaw>();
            EntityCollection response;
            do
            {
                response = _service.RetrieveMultiple(query);
                workflows.AddRange(response.Entities.Select(e => new ClassicWorkflowRaw
                {
                    Id = e.Id.ToString(),
                    Name = e.GetAttributeValue<string>("name"),
                    Category = e.GetAttributeValue<OptionSetValue>("category")?.Value ?? 0,
                    PrimaryEntity = e.GetAttributeValue<string>("primaryentity"),
                    TriggerOnCreate = e.GetAttributeValue<bool>("triggeroncreate") ? 1 : 0,
                    TriggerOnDelete = e.GetAttributeValue<bool>("triggerondelete") ? 1 : 0,
                    TriggerOnUpdateAttributeList = e.GetAttributeValue<string>("triggeronupdateattributelist"),
                    IsActive = e.GetAttributeValue<OptionSetValue>("statecode")?.Value == 1
                }));
                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = response.PagingCookie;
            }
            while (response.MoreRecords);

            FetchXamlInBatches(workflows);
            return workflows;
        }

        private void FetchXamlInBatches(List<ClassicWorkflowRaw> workflows)
        {
            for (int i = 0; i < workflows.Count; i += XamlBatchSize)
            {
                var batch = workflows.Skip(i).Take(XamlBatchSize).ToList();
                var multiRequest = new ExecuteMultipleRequest
                {
                    Requests = new OrganizationRequestCollection(),
                    Settings = new ExecuteMultipleSettings { ContinueOnError = true, ReturnResponses = true }
                };
                foreach (var wf in batch)
                {
                    multiRequest.Requests.Add(new RetrieveRequest
                    {
                        Target = new EntityReference("workflow", new Guid(wf.Id)),
                        ColumnSet = new ColumnSet("xaml")
                    });
                }
                var multiResponse = (ExecuteMultipleResponse)_service.Execute(multiRequest);
                for (int j = 0; j < batch.Count; j++)
                {
                    var item = multiResponse.Responses[j];
                    if (item.Response is RetrieveResponse r)
                        batch[j].XamlDefinition = r.Entity.GetAttributeValue<string>("xaml");
                }
            }
        }

        #endregion

        #region Index building

        private FlowIndex BuildCloudFlowIndex(FlowRaw flow, Dictionary<string, string> entityMap)
        {
            var index = new FlowIndex
            {
                Id = flow.Id,
                UniqueId = flow.UniqueId,
                Name = flow.Name,
                Category = flow.Category,
                EnvironmentId = flow.EnvironmentId,
                LastModified = flow.LastModified,
                LastIndexed = DateTime.UtcNow,
                IsActive = flow.IsActive
            };

            if (!string.IsNullOrWhiteSpace(flow.DefinitionJson))
            {
                try
                {
                    var definition = JObject.Parse(flow.DefinitionJson);
                    var condition = ParseFlowTrigger(flow.DefinitionJson);

                    index.Trigger = new FlowTriggerIndex
                    {
                        AutomationId = flow.Id,
                        TriggerType = condition.RawTriggerType,
                        EntityName = ResolveEntityName(condition.EntityName, entityMap),
                        TriggersOnCreate = condition.Operations.Contains(TriggerOperation.Create),
                        TriggersOnUpdate = condition.Operations.Contains(TriggerOperation.Update),
                        TriggersOnDelete = condition.Operations.Contains(TriggerOperation.Delete),
                        FilteringAttributes = condition.FilteringAttributes,
                        FilterExpression = condition.FilterExpression
                    };

                    index.Actions = ExtractDataverseActions(definition);
                    foreach (var a in index.Actions)
                    {
                        a.AutomationId = flow.Id;
                        a.EntityName = ResolveEntityName(a.EntityName, entityMap);
                    }
                }
                catch { }
            }

            return index;
        }

        private FlowIndex BuildClassicWorkflowIndex(ClassicWorkflowRaw wf)
        {
            return new FlowIndex
            {
                Id = wf.Id,
                UniqueId = wf.Id,
                Name = wf.Name,
                Category = wf.Category,
                EnvironmentId = null,
                LastModified = DateTime.MinValue,
                LastIndexed = DateTime.UtcNow,
                IsActive = wf.IsActive,
                Trigger = ParseClassicWorkflowTrigger(wf),
                Actions = ParseClassicWorkflowActions(wf)
            };
        }

        private static string ResolveEntityName(string rawName, Dictionary<string, string> entityMap)
        {
            if (string.IsNullOrEmpty(rawName)) return rawName;
            return entityMap.TryGetValue(rawName, out var logicalName) ? logicalName : rawName;
        }

        private void SaveFlowIndex(FlowIndex index)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    conn.Execute(
                        @"INSERT OR REPLACE INTO Automations
                          (Id, UniqueId, Name, Category, EnvironmentId, LastModified, LastIndexed, IsActive)
                          VALUES (@Id, @UniqueId, @Name, @Category, @EnvironmentId, @LastModified, @LastIndexed, @IsActive)",
                        new
                        {
                            index.Id, index.UniqueId, index.Name, index.Category,
                            index.EnvironmentId, index.LastModified, index.LastIndexed,
                            IsActive = index.IsActive ? 1 : 0
                        }, tx);

                    conn.Execute("DELETE FROM AutomationTriggerAttributes WHERE AutomationId = @Id", new { index.Id }, tx);
                    conn.Execute("DELETE FROM AutomationTriggers WHERE AutomationId = @Id", new { index.Id }, tx);

                    if (index.Trigger != null)
                    {
                        conn.Execute(
                            @"INSERT INTO AutomationTriggers
                              (AutomationId, TriggerType, EntityName,
                               TriggersOnCreate, TriggersOnUpdate, TriggersOnDelete, FilterExpression)
                              VALUES (@AutomationId, @TriggerType, @EntityName,
                                      @TriggersOnCreate, @TriggersOnUpdate, @TriggersOnDelete, @FilterExpression)",
                            new
                            {
                                AutomationId = index.Trigger.AutomationId,
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
                                "INSERT INTO AutomationTriggerAttributes (AutomationId, AttributeName) VALUES (@AutomationId, @AttributeName)",
                                new { AutomationId = index.Id, AttributeName = attr }, tx);
                        }
                    }

                    conn.Execute(@"
                        DELETE FROM AutomationActionFields
                        WHERE ActionId IN (SELECT Id FROM AutomationActions WHERE AutomationId = @Id)",
                        new { index.Id }, tx);
                    conn.Execute("DELETE FROM AutomationActions WHERE AutomationId = @Id", new { index.Id }, tx);

                    foreach (var action in index.Actions)
                    {
                        conn.Execute(
                            @"INSERT INTO AutomationActions
                              (AutomationId, ActionName, ActionType, EntityName, Description)
                              VALUES (@AutomationId, @ActionName, @ActionType, @EntityName, @Description)",
                            new
                            {
                                AutomationId = action.AutomationId,
                                action.ActionName, action.ActionType,
                                action.EntityName, action.Description
                            }, tx);

                        if (action.Fields?.Count > 0)
                        {
                            var actionId = conn.QueryFirstOrDefault<long>("SELECT last_insert_rowid()", transaction: tx);
                            foreach (var field in action.Fields)
                            {
                                conn.Execute(
                                    "INSERT INTO AutomationActionFields (ActionId, FieldName) VALUES (@ActionId, @FieldName)",
                                    new { ActionId = actionId, FieldName = field }, tx);
                            }
                        }
                    }

                    tx.Commit();
                }
            }
        }

        private void ComputeDependencies()
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
                            WHEN aa.ActionType != 'UpdateRecord' THEN 'Certain'
                            WHEN NOT EXISTS (
                                SELECT 1 FROM AutomationTriggerAttributes ata
                                WHERE ata.AutomationId = at.AutomationId
                            ) THEN 'Certain'
                            WHEN EXISTS (
                                SELECT 1 FROM AutomationActionFields aaf
                                JOIN AutomationTriggerAttributes ata
                                    ON ata.AutomationId = at.AutomationId
                                    AND ata.AttributeName = aaf.FieldName
                                WHERE aaf.ActionId = aa.Id
                            ) THEN 'Certain'
                            ELSE 'Possible'
                        END
                    FROM AutomationActions aa
                    JOIN AutomationTriggers at ON at.EntityName = aa.EntityName
                    WHERE aa.AutomationId != at.AutomationId
                      AND (
                        (at.TriggersOnCreate = 1 AND aa.ActionType = 'CreateRecord')
                        OR (at.TriggersOnDelete = 1 AND aa.ActionType = 'DeleteRecord')
                        OR (at.TriggersOnUpdate = 1 AND aa.ActionType = 'UpdateRecord'
                            AND (
                                -- No filtering attributes: any update qualifies
                                NOT EXISTS (
                                    SELECT 1 FROM AutomationTriggerAttributes ata
                                    WHERE ata.AutomationId = at.AutomationId
                                )
                                OR
                                -- Source writes at least one field the target watches
                                EXISTS (
                                    SELECT 1 FROM AutomationActionFields aaf
                                    JOIN AutomationTriggerAttributes ata
                                        ON ata.AutomationId = at.AutomationId
                                        AND ata.AttributeName = aaf.FieldName
                                    WHERE aaf.ActionId = aa.Id
                                )
                                OR
                                -- Source has no recorded fields (dynamic/unresolvable): keep as Possible
                                NOT EXISTS (
                                    SELECT 1 FROM AutomationActionFields aaf
                                    WHERE aaf.ActionId = aa.Id
                                )
                            ))
                      )");
            }
        }

        #endregion

        #region Flow trigger parsing

        private TriggerCondition ParseFlowTrigger(string flowDefinitionJson)
        {
            var definition = JObject.Parse(flowDefinitionJson);
            var triggers = definition["properties"]?["definition"]?["triggers"];

            if (triggers == null || !triggers.HasValues)
                throw new InvalidOperationException("No triggers found.");

            var trigger = triggers.First.First;
            var triggerType = trigger["type"]?.ToString();
            var condition = new TriggerCondition { RawTriggerType = triggerType };

            if (triggerType == "OpenApiConnectionWebhook")
                ParseDataverseTriggerParameters(trigger, condition);

            return condition;
        }

        private void ParseDataverseTriggerParameters(JToken trigger, TriggerCondition condition)
        {
            var parameters = trigger["inputs"]?["parameters"];
            condition.EntityName =
                parameters?["entityName"]?.ToString()
             ?? parameters?["subscriptionRequest/entityname"]?.ToString()
             ?? parameters?["table"]?.ToString();

            var messageMask =
                parameters?["message"]?.Value<int?>()
             ?? parameters?["subscriptionRequest/message"]?.Value<int?>()
             ?? 0;
            condition.Operations = DecodeTriggerMessageMask(messageMask);

            var filteringAttrs =
                parameters?["filteringattributes"]?.ToString()
             ?? parameters?["subscriptionRequest/filteringattributes"]?.ToString();
            if (!string.IsNullOrWhiteSpace(filteringAttrs))
            {
                condition.FilteringAttributes = filteringAttrs
                    .Split(',')
                    .Select(a => a.Trim())
                    .Where(a => !string.IsNullOrEmpty(a))
                    .ToList();
            }

            condition.FilterExpression =
                parameters?["filterExpression"]?.ToString()
             ?? parameters?["subscriptionRequest/filterExpression"]?.ToString();
        }

        private List<TriggerOperation> DecodeTriggerMessageMask(int mask)
        {
            var ops = new List<TriggerOperation>();
            switch (mask)
            {
                case 1: ops.Add(TriggerOperation.Create); break;
                case 2: ops.Add(TriggerOperation.Delete); break;
                case 3: ops.Add(TriggerOperation.Update); break;
                case 4:
                    ops.Add(TriggerOperation.Create);
                    ops.Add(TriggerOperation.Update);
                    ops.Add(TriggerOperation.Delete);
                    break;
                default:
                    if ((mask & 1) != 0) ops.Add(TriggerOperation.Create);
                    if ((mask & 2) != 0) ops.Add(TriggerOperation.Delete);
                    if ((mask & 4) != 0) ops.Add(TriggerOperation.Update);
                    break;
            }
            return ops;
        }

        private List<FlowActionIndex> ExtractDataverseActions(JObject definition)
        {
            var results = new List<FlowActionIndex>();
            var actions = definition["properties"]?["definition"]?["actions"];
            if (actions != null) WalkActions(actions, results);
            return results;
        }

        private void WalkActions(JToken actions, List<FlowActionIndex> results)
        {
            foreach (var action in actions.Children<JProperty>())
            {
                var type = action.Value["type"]?.ToString();
                switch (type)
                {
                    case "OpenApiConnection":
                        var operationId = action.Value["inputs"]?["host"]?["operationId"]?.ToString();
                        if (operationId == "CreateRecord" || operationId == "UpdateRecord" || operationId == "DeleteRecord")
                        {
                            results.Add(new FlowActionIndex
                            {
                                ActionName = action.Name,
                                ActionType = operationId,
                                EntityName = action.Value["inputs"]?["parameters"]?["entityName"]?.ToString(),
                                Fields = ExtractWrittenFields(action.Value["inputs"]?["parameters"])
                            });
                        }
                        break;
                    case "If":
                        var ifActions = action.Value["actions"];
                        var elseActions = action.Value["else"]?["actions"];
                        if (ifActions != null) WalkActions(ifActions, results);
                        if (elseActions != null) WalkActions(elseActions, results);
                        break;
                    case "Foreach":
                    case "Scope":
                        var inner = action.Value["actions"];
                        if (inner != null) WalkActions(inner, results);
                        break;
                    case "Switch":
                        foreach (var switchCase in action.Value["cases"]?.Children<JProperty>() ?? Enumerable.Empty<JProperty>())
                        {
                            var caseActions = switchCase.Value["actions"];
                            if (caseActions != null) WalkActions(caseActions, results);
                        }
                        var defaultActions = action.Value["default"]?["actions"];
                        if (defaultActions != null) WalkActions(defaultActions, results);
                        break;
                }
            }
        }

        private List<string> ExtractWrittenFields(JToken parameters)
        {
            if (parameters == null) return new List<string>();
            return parameters.Children<JProperty>()
                .Where(p => p.Name.StartsWith("item/"))
                .Select(p => p.Name.Substring(5))
                .ToList();
        }

        #endregion

        #region Classic workflow parsing

        private FlowTriggerIndex ParseClassicWorkflowTrigger(ClassicWorkflowRaw wf)
        {
            var trigger = new FlowTriggerIndex
            {
                AutomationId = wf.Id,
                TriggerType = "ClassicWorkflow",
                EntityName = wf.PrimaryEntity,
                TriggersOnCreate = wf.TriggerOnCreate == 1,
                TriggersOnDelete = wf.TriggerOnDelete == 1,
                TriggersOnUpdate = !string.IsNullOrWhiteSpace(wf.TriggerOnUpdateAttributeList),
                FilteringAttributes = new List<string>()
            };

            if (trigger.TriggersOnUpdate)
            {
                trigger.FilteringAttributes = wf.TriggerOnUpdateAttributeList
                    .Split(',')
                    .Select(a => a.Trim())
                    .Where(a => !string.IsNullOrEmpty(a))
                    .ToList();
            }

            return trigger;
        }

        private List<FlowActionIndex> ParseClassicWorkflowActions(ClassicWorkflowRaw wf)
        {
            var actions = new List<FlowActionIndex>();
            if (string.IsNullOrWhiteSpace(wf.XamlDefinition)) return actions;

            try
            {
                var doc = XDocument.Parse(wf.XamlDefinition);
                var map = new Dictionary<string, string>
                {
                    { "CreateEntity", "CreateRecord" },
                    { "UpdateEntity", "UpdateRecord" },
                    { "DeleteEntity", "DeleteRecord" },
                    { "StartChildWorkflow", "StartChildWorkflow" }
                };

                foreach (var kvp in map)
                {
                    foreach (var step in doc.Descendants().Where(e => e.Name.LocalName == kvp.Key))
                    {
                        actions.Add(new FlowActionIndex
                        {
                            AutomationId = wf.Id,
                            ActionName = step.Attribute(_xamlNs + "Name")?.Value ?? kvp.Key,
                            ActionType = kvp.Value,
                            EntityName = step.Attribute("EntityName")?.Value,
                            Description = step.Attribute("DisplayName")?.Value,
                            Fields = ExtractXamlFields(step)
                        });
                    }
                }
            }
            catch { }

            return actions;
        }

        private List<string> ExtractXamlFields(XElement step)
        {
            var entityVar = step.Attribute("Entity")?.Value;
            if (string.IsNullOrEmpty(entityVar) || step.Parent == null)
                return new List<string>();

            return step.Parent.Descendants()
                .Where(e => e.Name.LocalName == "SetEntityProperty"
                         && e.Attribute("Entity")?.Value == entityVar)
                .Select(e => e.Attribute("Attribute")?.Value)
                .Where(a => !string.IsNullOrEmpty(a))
                .Distinct()
                .ToList();
        }

        #endregion
    }
}
