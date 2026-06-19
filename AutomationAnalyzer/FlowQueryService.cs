using System.Collections.Generic;
using System.Linq;
using Dapper;

namespace Automation_Analyzer
{
    public class FlowQueryService
    {
        private readonly DatabaseManager _db;

        public FlowQueryService(DatabaseManager db)
        {
            _db = db;
        }

        public List<FlowDependency> GetFlowsThatCanTrigger(string targetFlowName)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                return conn.Query<FlowDependency>(@"
                    SELECT sa.Name     AS SourceFlowName,
                           sa.IsActive AS SourceIsActive,
                           ta.Name     AS TargetFlowName,
                           ta.IsActive AS TargetIsActive,
                           d.MatchReason, d.Confidence
                    FROM AutomationDependencies d
                    JOIN Automations sa ON sa.Id = d.SourceAutomationId
                    JOIN Automations ta ON ta.Id = d.TargetAutomationId
                    WHERE ta.Name = @targetFlowName",
                    new { targetFlowName }).ToList();
            }
        }

        public List<string> GetFullTriggerChain(string flowName, int depth = 5)
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                return conn.Query<string>(@"
                    WITH RECURSIVE chain(SourceName, TargetName, Depth) AS (
                        SELECT sa.Name, ta.Name, 1
                        FROM AutomationDependencies d
                        JOIN Automations sa ON sa.Id = d.SourceAutomationId
                        JOIN Automations ta ON ta.Id = d.TargetAutomationId
                        WHERE sa.Name = @flowName

                        UNION ALL

                        SELECT chain.TargetName, ta2.Name, chain.Depth + 1
                        FROM chain
                        JOIN AutomationDependencies d2 ON d2.SourceAutomationId = (
                            SELECT Id FROM Automations WHERE Name = chain.TargetName)
                        JOIN Automations ta2 ON ta2.Id = d2.TargetAutomationId
                        WHERE chain.Depth < @depth
                    )
                    SELECT DISTINCT TargetName FROM chain",
                    new { flowName, depth }).ToList();
            }
        }

        public List<FlowDependency> GetAllDependencies()
        {
            using (var conn = _db.GetConnection())
            {
                conn.Open();
                return conn.Query<FlowDependency>(@"
                    SELECT sa.Name     AS SourceFlowName,
                           sa.IsActive AS SourceIsActive,
                           ta.Name     AS TargetFlowName,
                           ta.IsActive AS TargetIsActive,
                           d.MatchReason, d.Confidence
                    FROM AutomationDependencies d
                    JOIN Automations sa ON sa.Id = d.SourceAutomationId
                    JOIN Automations ta ON ta.Id = d.TargetAutomationId
                    ORDER BY ta.Name, sa.Name").ToList();
            }
        }
    }
}
