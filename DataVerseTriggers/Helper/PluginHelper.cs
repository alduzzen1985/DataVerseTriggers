using System;
using System.Text;
using DataVerseTrigger.Models;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace DataVerseTrigger.Helper
{


    public class PluginHelper
    {
        private static string FetchXMLPlugins = @"<fetch>
  <entity name='solutioncomponent'>
    <link-entity name='sdkmessageprocessingstep' to='objectid' from='sdkmessageprocessingstepid' alias='SPM' link-type='inner'>
      <attribute name='sdkmessageprocessingstepid' />
      <attribute name='name' />
      <attribute name='sdkmessageid' />
      <attribute name='componentstate' />
      <attribute name='filteringattributes' />
      <attribute name='mode' />
      <attribute name='sdkmessagefilterid' />
      <attribute name='stage' />
	  
      <link-entity name='sdkmessagefilter' to='sdkmessagefilterid' from='sdkmessagefilterid' alias='SMF' link-type='inner'>
        <attribute name='primaryobjecttypecode' />
        @@FILTERS_TABLE
      </link-entity>

	    <filter>
            <condition attribute='stage' operator='in'>
		        <value>10</value>
		        <value>20</value>
		        <value>40</value>
	        </condition>
            @@FILTERS_SPM

        </filter>
    </link-entity>
    <filter>
      <condition attribute='componenttype' operator='eq' value='92' />
      <condition attribute='solutionid' operator='eq' value='@@SOLUTION_ID' />
    </filter>
  </entity>
</fetch>";



        private static string FetchXMLPluginMessages = @"<fetch>
  <entity name='sdkmessage'>
    <attribute name='sdkmessageid' />
    <attribute name='name' />
    <filter>
      <condition attribute='name' operator='in'>
        <value>Create</value>
        <value>Update</value>
        <value>Delete</value>
        <value>Retrieve</value>
        <value>RetrieveMultiple</value>
      </condition>
    </filter>
  </entity>
</fetch>";



        public static Plugin[] GetPlugins(IOrganizationService Service, Guid solutionId)
        {
            string fetchExpression = FetchXMLPlugins.Replace("@@FILTERS_TABLE", "").Replace("@@FILTERS_SPM", "").Replace("@@SOLUTION_ID", solutionId.ToString());
            return GetPluginDetails(Service.RetrieveMultiple(new FetchExpression(fetchExpression)));
        }


        public static Plugin[] GetPlugins(IOrganizationService Service, Guid solutionId,int? tableObjectTypeCode, Guid[] messages, int[] stages, int[] executionMode, string[] attributes)
        {
            string filtersTable = "";

            if (tableObjectTypeCode != null)
            {
                filtersTable = $@"<filter><condition attribute='primaryobjecttypecode' operator='eq' value='{tableObjectTypeCode}' /></filter>";
            }

            StringBuilder filtersSPM = new StringBuilder();

            if (messages.Length > 0)
            {
                filtersSPM.Append("<condition attribute='sdkmessageid' operator='in'>");
                foreach (Guid message in messages)
                {
                    filtersSPM.Append($"<value>{message}</value>");
                }
                filtersSPM.Append("</condition>");
            }


            if (stages.Length > 0)
            {
                filtersSPM.Append("<condition attribute='stage' operator='in'>");
                foreach (int stage in stages)
                {
                    filtersSPM.Append($"<value>{stage}</value>");
                }
                filtersSPM.Append("</condition>");
            }



            if (executionMode.Length > 0)
            {
                filtersSPM.Append("<condition attribute='mode' operator='in'>");
                foreach (int exMode in executionMode)
                {
                    filtersSPM.Append($"<value>{exMode}</value>");
                }
                filtersSPM.Append("</condition>");
            }


            if (attributes.Length > 0)
            {
                filtersSPM.AppendLine("<filter type='or'>");
                foreach (string attribute in attributes)
                {
                    filtersSPM.AppendLine($"<condition attribute='filteringattributes' operator='like' value='%{attribute}%' />");
                }
                filtersSPM.AppendLine("</filter>");
            }

            string fetchExpression = FetchXMLPlugins.Replace("@@FILTERS_TABLE", filtersTable);
            fetchExpression = fetchExpression.Replace("@@FILTERS_SPM", filtersSPM.ToString()).Replace("@@SOLUTION_ID", solutionId.ToString());

            return GetPluginDetails(Service.RetrieveMultiple(new FetchExpression(fetchExpression)));
        }

        private static Plugin[] GetPluginDetails(EntityCollection pluginsCollection)
        {
            Plugin[] plugins = new Plugin[pluginsCollection.Entities.Count];

            int i = 0;
            foreach (Entity plugin in pluginsCollection.Entities)
            {
                plugins[i++] = new Plugin()
                {
                    Name = (string)plugin.GetAttributeValue<AliasedValue>("SPM.name").Value,
                    ComponentStateName = plugin.FormattedValues["SPM.componentstate"],
                    ComponentState = (plugin.GetAttributeValue<AliasedValue>("SPM.componentstate").Value as OptionSetValue).Value,
                    FilteringAttributes = plugin.GetAttributeValue<AliasedValue>("SPM.filteringattributes") != null ? (string)plugin.GetAttributeValue<AliasedValue>("SPM.filteringattributes").Value : "",
                    Mode = (plugin.GetAttributeValue<AliasedValue>("SPM.mode").Value as OptionSetValue).Value,
                    ModeName = plugin.FormattedValues["SPM.mode"],
                    Stage = (plugin.GetAttributeValue<AliasedValue>("SPM.stage").Value as OptionSetValue).Value,
                    StageName = plugin.FormattedValues["SPM.stage"],
                    SdkMessageFilterIdName = (plugin.GetAttributeValue<AliasedValue>("SPM.sdkmessagefilterid").Value as EntityReference).Name,
                    SdkMessageProcessingStepId = (Guid)plugin.GetAttributeValue<AliasedValue>("SPM.sdkmessageprocessingstepid").Value,
                    SdkMessageId = ((EntityReference)plugin.GetAttributeValue<AliasedValue>("SPM.sdkmessageid").Value as EntityReference).Id,
                    PrimaryObjectTypeCode = (string)plugin.GetAttributeValue<AliasedValue>("SMF.primaryobjecttypecode").Value,
                    SdkMessageIdName = ((EntityReference)plugin.GetAttributeValue<AliasedValue>("SPM.sdkmessageid").Value as EntityReference).Name
                };
            }

            return plugins;
        }


        public static EntityCollection GetCRUDPluginMessages(IOrganizationService Service)
        {
            return Service.RetrieveMultiple(new FetchExpression(FetchXMLPluginMessages));
        }



    }
}
