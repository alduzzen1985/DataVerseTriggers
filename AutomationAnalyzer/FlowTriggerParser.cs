using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Automation_Analyzer
{
    public class FlowTriggerParser
    {
        public TriggerCondition GetTriggerCondition(string flowDefinitionJson)
        {
            var definition = JObject.Parse(flowDefinitionJson);
            var triggers = definition["properties"]?["definition"]?["triggers"];

            if (triggers == null || !triggers.HasValues)
                throw new InvalidOperationException("No triggers found.");

            var trigger = triggers.First.First;
            var triggerType = trigger["type"]?.ToString();
            var condition = new TriggerCondition { RawTriggerType = triggerType };

            switch (triggerType)
            {
                case "OpenApiConnectionWebhook":
                    ParseDataverseTrigger(trigger, condition);
                    break;
                case "Recurrence":
                case "Request":
                    condition.EntityName = null;
                    break;
                default:
                    condition.EntityName = null;
                    break;
            }

            return condition;
        }

        private void ParseDataverseTrigger(JToken trigger, TriggerCondition condition)
        {
            var parameters = trigger["inputs"]?["parameters"];

            // Two parameter naming conventions exist in the wild:
            //   Classic: "entityName", "message", "filteringattributes"
            //   Webhook (SubscribeWebhookTrigger): "subscriptionRequest/entityname", etc.
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

        // Power Automate message mask is NOT a standard bitmask:
        // 1=Create, 2=Delete, 3=Update, 4=Create+Update+Delete
        private List<TriggerOperation> DecodeTriggerMessageMask(int mask)
        {
            var operations = new List<TriggerOperation>();
            switch (mask)
            {
                case 1: operations.Add(TriggerOperation.Create); break;
                case 2: operations.Add(TriggerOperation.Delete); break;
                case 3: operations.Add(TriggerOperation.Update); break;
                case 4:
                    operations.Add(TriggerOperation.Create);
                    operations.Add(TriggerOperation.Update);
                    operations.Add(TriggerOperation.Delete);
                    break;
                default:
                    if ((mask & 1) != 0) operations.Add(TriggerOperation.Create);
                    if ((mask & 2) != 0) operations.Add(TriggerOperation.Delete);
                    if ((mask & 4) != 0) operations.Add(TriggerOperation.Update);
                    break;
            }
            return operations;
        }

        public List<FlowActionIndex> ExtractDataverseActions(JObject definition)
        {
            var results = new List<FlowActionIndex>();
            var actions = definition["properties"]?["definition"]?["actions"];
            if (actions != null)
                WalkActions(actions, results);
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
                        if (operationId == "CreateRecord" ||
                            operationId == "UpdateRecord" ||
                            operationId == "DeleteRecord")
                        {
                            results.Add(new FlowActionIndex
                            {
                                ActionName = action.Name,
                                ActionType = operationId,
                                EntityName = action.Value["inputs"]?["parameters"]?["entityName"]?.ToString(),
                                Fields     = ExtractWrittenFields(action.Value["inputs"]?["parameters"])
                            });
                        }
                        break;

                    case "If":
                        var ifActions   = action.Value["actions"];
                        var elseActions = action.Value["else"]?["actions"];
                        if (ifActions   != null) WalkActions(ifActions,   results);
                        if (elseActions != null) WalkActions(elseActions, results);
                        break;

                    case "Foreach":
                    case "Scope":
                        var inner = action.Value["actions"];
                        if (inner != null) WalkActions(inner, results);
                        break;

                    case "Switch":
                        foreach (var switchCase in action.Value["cases"]?.Children<JProperty>()
                                 ?? Enumerable.Empty<JProperty>())
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
    }
}
