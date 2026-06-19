using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Automation_Analyzer
{
    public class ClassicWorkflowParser
    {
        private static readonly XNamespace xaml =
            "http://schemas.microsoft.com/winfx/2006/xaml";

        // Trigger data comes from Dataverse entity fields, not from the XAML
        public FlowTriggerIndex ParseTrigger(ClassicWorkflowRaw workflow)
        {
            var trigger = new FlowTriggerIndex
            {
                AutomationId        = workflow.Id,
                TriggerType         = "ClassicWorkflow",
                EntityName          = workflow.PrimaryEntity,
                TriggersOnCreate    = workflow.TriggerOnCreate == 1,
                TriggersOnDelete    = workflow.TriggerOnDelete == 1,
                TriggersOnUpdate    = !string.IsNullOrWhiteSpace(workflow.TriggerOnUpdateAttributeList),
                FilteringAttributes = new List<string>()
            };

            if (trigger.TriggersOnUpdate)
            {
                trigger.FilteringAttributes = workflow.TriggerOnUpdateAttributeList
                    .Split(',')
                    .Select(a => a.Trim())
                    .Where(a => !string.IsNullOrEmpty(a))
                    .ToList();
            }

            return trigger;
        }

        public List<FlowActionIndex> ParseActions(ClassicWorkflowRaw workflow)
        {
            var actions = new List<FlowActionIndex>();
            if (string.IsNullOrWhiteSpace(workflow.XamlDefinition))
                return actions;

            try
            {
                var doc = XDocument.Parse(workflow.XamlDefinition);

                var map = new Dictionary<string, string>
                {
                    { "CreateEntity",       "CreateRecord"       },
                    { "UpdateEntity",       "UpdateRecord"       },
                    { "DeleteEntity",       "DeleteRecord"       },
                    { "StartChildWorkflow", "StartChildWorkflow" }
                };

                foreach (var kvp in map)
                {
                    // Match by local name to handle any version of the namespace URI
                    // (Dataverse XAML includes full assembly version/key in namespace)
                    foreach (var step in doc.Descendants().Where(e => e.Name.LocalName == kvp.Key))
                    {
                        actions.Add(new FlowActionIndex
                        {
                            AutomationId = workflow.Id,
                            ActionName   = step.Attribute(xaml + "Name")?.Value ?? kvp.Key,
                            ActionType   = kvp.Value,
                            EntityName   = step.Attribute("EntityName")?.Value,
                            Description  = step.Attribute("DisplayName")?.Value,
                            Fields       = ExtractFieldsFromParentSequence(step)
                        });
                    }
                }
            }
            catch (Exception)
            {
                // Large or malformed XAML — return whatever was parsed
            }

            return actions;
        }

        // Fields for a Create/Update step are set by mxswa:SetEntityProperty siblings
        // within the same parent Sequence. Each SetEntityProperty shares the same
        // Entity variable reference as the step itself (e.g. [CreatedEntities("CreateStep3_localParameter#Temp")]).
        private List<string> ExtractFieldsFromParentSequence(XElement step)
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
    }
}
