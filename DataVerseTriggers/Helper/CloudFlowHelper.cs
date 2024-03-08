using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace DataVerseTrigger.Helper
{
    public class CloudFlowHelper
    {



        public static EntityCollection GetCloudFlows(IOrganizationService Service, Guid solutionId)
        {
            if (Service == null) return null;


            string fetchXMLCloudFlows = $@"<fetch>
  <entity name='solutioncomponent'>
    <link-entity name='workflow' to='objectid' from='workflowid' alias='workflow' link-type='inner'>
      <attribute name='category' />
      <attribute name='clientdata' />
      <attribute name='statuscode' />
      <attribute name='workflowid' />
      <attribute name='workflowidunique' />
      <attribute name='solutionid' />
      <attribute name='name' />
      <attribute name='statecode' />
      <filter>
        <condition attribute='category' operator='eq' value='5' />
      </filter>
    </link-entity>
    <filter>
      <condition attribute='solutionid' operator='eq' value='{solutionId.ToString()}' />
      <condition attribute='componenttype' operator='eq' value='29' />
    </filter>
  </entity>
</fetch>";

            return Service.RetrieveMultiple(new FetchExpression(fetchXMLCloudFlows));


        }



    }
}
