using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataVerseTrigger.Enums;
using DataVerseTrigger.Models;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using static DataVerseTrigger.Extensions.BaseControl;

namespace DataVerseTrigger.Helper
{
    public static class WorkflowHelper
    {

        private static string fetchXML = $@"<fetch>
                          <entity name='solutioncomponent'>
                            <link-entity name='workflow' to='objectid' from='workflowid' alias='workflow' link-type='inner'>
                                <attribute name='name' />  
                                <attribute name='category' />
                                <attribute name='workflowid' />
                                <attribute name='workflowidunique' />
                                <attribute name='statuscode' />
                                <attribute name='triggeroncreate' />
                                <attribute name='triggerondelete' />
                                <attribute name='triggeronupdateattributelist' />
                                <attribute name='mode' />
                                <attribute name='ondemand' />
                                <attribute name='primaryentity' />
                                <attribute name='scope' />
                                <attribute name='createstage' />
                                <attribute name='updatestage' />
                                <attribute name='deletestage' />
                                <attribute name='subprocess' />
                                <filter>
                                    <condition attribute='category' operator='eq' value='0' />
                                    @CONDITIONS@
                                </filter>
                            </link-entity>
                            <filter>
                              <condition attribute='solutionid' operator='eq' value='@SOLUTIONID@' />
                            </filter>
                          </entity>
                        </fetch>";

        public static List<ClassicWorkflow> GetWorkflows(IOrganizationService Service, Guid solutionId)
        {
            if (Service == null) return null;
            return GetWorkflowDetails(Service.RetrieveMultiple(new FetchExpression(fetchXML.Replace("@SOLUTIONID@", solutionId.ToString()).Replace("@CONDITIONS@", ""))));
        }



        public static List<ClassicWorkflow> GetWorkflowsByFilters(IOrganizationService Service, Guid solutionId,
            bool triggeroncreate,
            bool triggerondelete,
            bool triggerOnUpdate,
            bool triggerOnAssign,
            bool onStatusChanged,
            string[] attributesOnUpdate,

            Mode[] modes,
            Scope[] scopes,
            int? tableObjectCode,
            bool isOnDemand
            )
        {

            StringBuilder conditions = new StringBuilder();

            if (triggeroncreate)
            {
                conditions.AppendLine("<condition attribute='triggeroncreate' operator='eq' value='1' />");
            }

            if (triggerondelete)
            {
                conditions.AppendLine("<condition attribute='triggerondelete' operator='eq' value='1' />");
            }

            if (triggerOnAssign)
            {
                conditions.AppendLine("<condition attribute='triggeronupdateattributelist' operator='like' value='%ownerid%' />");
            }

            if (onStatusChanged)
            {
                conditions.AppendLine("<condition attribute='triggeronupdateattributelist' operator='like' value='%statecode%' />");
            }

            if (modes.Length > 0)
            {
                conditions.AppendLine("<filter type='or'>");
                foreach (Mode mode in modes)
                {
                    conditions.AppendLine($"<condition attribute='mode' operator='eq' value='{(int)mode}' />");
                }
                conditions.AppendLine("</filter>");
            }



            if (scopes.Length > 0)
            {
                conditions.AppendLine("<filter type='or'>");
                foreach (Scope scope in scopes)
                {
                    conditions.AppendLine($"<condition attribute='scope' operator='eq' value='{(int)scope}' />");
                }
                conditions.AppendLine("</filter>");
            }


            if (tableObjectCode != null)
            {
                conditions.AppendLine($"<condition attribute='primaryentity' operator='eq' value='{tableObjectCode}' />");
            }

            if (isOnDemand)
            {
                conditions.AppendLine("<condition attribute='ondemand' operator='eq' value='1' />");
            }

            if (attributesOnUpdate != null && attributesOnUpdate.Any())
            {
                conditions.AppendLine("<filter type='or'>");
                foreach (string attribute in attributesOnUpdate)
                {
                    conditions.AppendLine($"<condition attribute='triggeronupdateattributelist' operator='like' value='{attribute}' />");
                }
                conditions.AppendLine("</filter>");
            }

            //TODO : FilterByAttributes
            string fetch = fetchXML.Replace("@SOLUTIONID@", solutionId.ToString()).Replace("@CONDITIONS@", conditions.ToString());
            return GetWorkflowDetails(Service.RetrieveMultiple(new FetchExpression(fetchXML.Replace("@SOLUTIONID@", solutionId.ToString()).Replace("@CONDITIONS@", conditions.ToString()))));

        }

        private static List<ClassicWorkflow> GetWorkflowDetails(EntityCollection workflowCollection)
        {
            List<ClassicWorkflow> lsClassicWorkflows = new List<ClassicWorkflow>();

            foreach (var workflow in workflowCollection.Entities)
            {
                ClassicWorkflow classicWorkflow = new ClassicWorkflow()
                {
                    Name = (string)workflow.GetAttributeValue<AliasedValue>("workflow.name").Value,
                    Workflowid = (Guid)workflow.GetAttributeValue<AliasedValue>("workflow.workflowid").Value,
                    Workflowuniqueid = (Guid)workflow.GetAttributeValue<AliasedValue>("workflow.workflowidunique").Value,
                    Status = ((OptionSetValue)workflow.GetAttributeValue<AliasedValue>("workflow.statuscode").Value).Value,
                    StatusName = workflow.FormattedValues["workflow.statuscode"],
                    Scope = (WorkflowScope)((OptionSetValue)workflow.GetAttributeValue<AliasedValue>("workflow.scope").Value).Value,
                    ScopeName = workflow.FormattedValues["workflow.scope"],

                    TriggerOnCreate = (bool)workflow.GetAttributeValue<AliasedValue>("workflow.triggeroncreate").Value,

                    TriggerOnDelete = (bool)workflow.GetAttributeValue<AliasedValue>("workflow.triggerondelete").Value,


                    TriggerOnUpdateAttributeList = workflow.GetAttributeValue<AliasedValue>("workflow.triggeronupdateattributelist") != null ?
                                                (string)workflow.GetAttributeValue<AliasedValue>("workflow.triggeronupdateattributelist").Value : string.Empty,



                    OnDemand = (bool)workflow.GetAttributeValue<AliasedValue>("workflow.ondemand").Value,
                    OnDemandName = workflow.FormattedValues["workflow.ondemand"],


                    AsChildProcess = (bool)workflow.GetAttributeValue<AliasedValue>("workflow.subprocess").Value,

                    Primaryentityname = (string)workflow.GetAttributeValue<AliasedValue>("workflow.primaryentity").Value,
                    Mode = (Mode)((OptionSetValue)workflow.GetAttributeValue<AliasedValue>("workflow.mode").Value).Value

                };


                classicWorkflow.TriggerOnAssign = (!string.IsNullOrEmpty(classicWorkflow.TriggerOnUpdateAttributeList) &&
                classicWorkflow.TriggerOnUpdateAttributeList.Contains("ownerid"));

                classicWorkflow.TriggerOnStatusChange = (!string.IsNullOrEmpty(classicWorkflow.TriggerOnUpdateAttributeList) &&
                classicWorkflow.TriggerOnUpdateAttributeList.Contains("statecode"));


                classicWorkflow.TriggerOnUpdate = !string.IsNullOrEmpty(classicWorkflow.TriggerOnUpdateAttributeList) && classicWorkflow.TriggerOnUpdateAttributeList.Split(',').Where(x => x != "ownerid" && x != "statecode").Any();

             
                lsClassicWorkflows.Add(classicWorkflow);
            }

            return lsClassicWorkflows;
        }


    }
}
