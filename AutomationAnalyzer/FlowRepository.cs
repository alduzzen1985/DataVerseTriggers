using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Automation_Analyzer
{
    public class FlowRepository
    {
        private readonly ServiceClient _serviceClient;

        public FlowRepository(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public Task<List<FlowRaw>> GetAllCloudFlowsAsync(string environmentId)
        {
            return Task.Run(() => FetchCloudFlows(environmentId, sinceDate: null));
        }

        public Task<List<FlowRaw>> GetFlowsModifiedAfterAsync(string environmentId, DateTime since)
        {
            return Task.Run(() => FetchCloudFlows(environmentId, sinceDate: since));
        }

        private List<FlowRaw> FetchCloudFlows(string environmentId, DateTime? sinceDate)
        {
            var query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet("workflowid", "name", "category", "modifiedon", "clientdata", "statecode"),
                PageInfo  = new PagingInfo { Count = 5000, PageNumber = 1, ReturnTotalRecordCount = false }
            };

            query.Criteria.AddCondition("category", ConditionOperator.Equal, 5);
            query.Criteria.AddCondition("type", ConditionOperator.Equal, 1);

            if (sinceDate.HasValue) 
                query.Criteria.AddCondition("modifiedon", ConditionOperator.GreaterThan, sinceDate.Value);

            var results = new List<FlowRaw>();
            EntityCollection response;

            do
            {
                response = _serviceClient.RetrieveMultiple(query);
                results.AddRange(response.Entities.Select(e => new FlowRaw
                {
                    Id             = e.Id.ToString(),
                    Name           = e.GetAttributeValue<string>("name"),
                    Category       = e.GetAttributeValue<OptionSetValue>("category")?.Value ?? 5,
                    EnvironmentId  = environmentId,
                    LastModified   = e.GetAttributeValue<DateTime>("modifiedon"),
                    DefinitionJson = e.GetAttributeValue<string>("clientdata"),
                    IsActive       = e.GetAttributeValue<OptionSetValue>("statecode")?.Value == 1
                }));

                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = response.PagingCookie;
            }
            while (response.MoreRecords);

            return results;
        }
    }
}
