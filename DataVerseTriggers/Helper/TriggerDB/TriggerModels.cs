using System;
using System.Collections.Generic;

namespace DataVerseTrigger.Helper.TriggerDB
{
    internal class FlowRaw
    {
        public string Id { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string EnvironmentId { get; set; }
        public DateTime LastModified { get; set; }
        public string DefinitionJson { get; set; }
        public bool IsActive { get; set; }
    }

    internal class ClassicWorkflowRaw
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string PrimaryEntity { get; set; }
        public int TriggerOnCreate { get; set; }
        public int TriggerOnDelete { get; set; }
        public string TriggerOnUpdateAttributeList { get; set; }
        public bool IsActive { get; set; }
        public string XamlDefinition { get; set; }
    }

    internal class FlowIndex
    {
        public string Id { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string EnvironmentId { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastIndexed { get; set; }
        public bool IsActive { get; set; }
        public FlowTriggerIndex Trigger { get; set; }
        public List<FlowActionIndex> Actions { get; set; } = new List<FlowActionIndex>();
    }

    internal class FlowTriggerIndex
    {
        public string AutomationId { get; set; }
        public string TriggerType { get; set; }
        public string EntityName { get; set; }
        public bool TriggersOnCreate { get; set; }
        public bool TriggersOnUpdate { get; set; }
        public bool TriggersOnDelete { get; set; }
        public List<string> FilteringAttributes { get; set; } = new List<string>();
        public string FilterExpression { get; set; }
    }

    internal class FlowActionIndex
    {
        public string AutomationId { get; set; }
        public string ActionName { get; set; }
        public string ActionType { get; set; }
        public string EntityName { get; set; }
        public string Description { get; set; }
        public List<string> Fields { get; set; } = new List<string>();
    }

    internal class TriggerCondition
    {
        public string EntityName { get; set; }
        public List<TriggerOperation> Operations { get; set; } = new List<TriggerOperation>();
        public List<string> FilteringAttributes { get; set; } = new List<string>();
        public string FilterExpression { get; set; }
        public string RawTriggerType { get; set; }
    }

    internal enum TriggerOperation
    {
        Create = 1,
        Update = 2,
        Delete = 4
    }

    public class TriggerSourceRow
    {
        public string Id { get; set; }
        public string UniqueId { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public bool IsActive { get; set; }
        public string MatchReason { get; set; }
        public string Confidence { get; set; }

        public string StatusName => IsActive ? "Active" : "Inactive";
    }

    public class TriggerStepRow
    {
        public string ActionName { get; set; }
        public string ActionType { get; set; }
        public string EntityName { get; set; }
        public string Description { get; set; }
    }
}
