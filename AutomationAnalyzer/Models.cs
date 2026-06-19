using System;
using System.Collections.Generic;

namespace Automation_Analyzer
{
    public class FlowRaw
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string EnvironmentId { get; set; }
        public DateTime LastModified { get; set; }
        public string DefinitionJson { get; set; }
        public bool IsActive { get; set; }
    }

    public class ClassicWorkflowRaw
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string PrimaryEntity { get; set; }
        public int TriggerOnCreate { get; set; }
        public int TriggerOnDelete { get; set; }
        public string TriggerOnUpdateAttributeList { get; set; }
        public int Scope { get; set; }
        public string XamlDefinition { get; set; }
        public bool IsActive { get; set; }
    }

    public class FlowIndex
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string EnvironmentId { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastIndexed { get; set; }
        public bool IsActive { get; set; }
        public FlowTriggerIndex Trigger { get; set; }
        public List<FlowActionIndex> Actions { get; set; } = new List<FlowActionIndex>();
    }

    public class FlowTriggerIndex
    {
        public string AutomationId { get; set; }
        public string TriggerType { get; set; }
        public string EntityName { get; set; }
        public bool TriggersOnCreate { get; set; }
        public bool TriggersOnUpdate { get; set; }
        public bool TriggersOnDelete { get; set; }
        // Kept in-memory for saving to AutomationTriggerAttributes child table
        public List<string> FilteringAttributes { get; set; } = new List<string>();
        public string FilterExpression { get; set; }
    }

    public class FlowActionIndex
    {
        public string AutomationId { get; set; }
        public string ActionName { get; set; }
        public string ActionType { get; set; }
        public string EntityName { get; set; }
        public string Description { get; set; }
        // Kept in-memory for saving to AutomationActionFields child table
        public List<string> Fields { get; set; } = new List<string>();
    }

    public class FlowDependency
    {
        public string SourceAutomationId { get; set; }
        public string SourceFlowName { get; set; }
        public bool SourceIsActive { get; set; }
        public string TargetAutomationId { get; set; }
        public string TargetFlowName { get; set; }
        public bool TargetIsActive { get; set; }
        public string MatchReason { get; set; }
        public string Confidence { get; set; }
    }

    public class TriggerCondition
    {
        public string EntityName { get; set; }
        public List<TriggerOperation> Operations { get; set; } = new List<TriggerOperation>();
        public List<string> FilteringAttributes { get; set; } = new List<string>();
        public string FilterExpression { get; set; }
        public string RawTriggerType { get; set; }
    }

    public enum TriggerOperation
    {
        Create = 1,
        Update = 2,
        Delete = 4
    }
}
