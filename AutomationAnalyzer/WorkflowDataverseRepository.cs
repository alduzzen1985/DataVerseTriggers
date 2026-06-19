using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace Automation_Analyzer
{
    public class WorkflowDataverseRepository
    {
        private readonly ServiceClient _serviceClient;
        private const int XamlBatchSize = 50;

        public WorkflowDataverseRepository(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        public List<ClassicWorkflowRaw> GetAllClassicWorkflows()
        {
            // Phase 1: bulk fetch metadata (no xaml — Dataverse silently drops large
            // Memo fields in RetrieveMultiple, so we fetch it separately below)
            var query = new QueryExpression("workflow")
            {
                ColumnSet = new ColumnSet(
                    "workflowid", "name", "category", "primaryentity",
                    "triggeroncreate", "triggerondelete",
                    "triggeronupdateattributelist", "scope", "statecode"),
                PageInfo = new PagingInfo { Count = 5000, PageNumber = 1, ReturnTotalRecordCount = false }
            };

            query.Criteria.AddCondition("category", ConditionOperator.Equal, 0);
            // type=1 means Definition; Dataverse also stores Activation copies (type=2)
            // and Templates (type=3) — we only want the canonical definition.
            query.Criteria.AddCondition("type", ConditionOperator.Equal, 1);

            var workflows = new List<ClassicWorkflowRaw>();
            EntityCollection response;

            do
            {
                response = _serviceClient.RetrieveMultiple(query);
                workflows.AddRange(response.Entities.Select(e => new ClassicWorkflowRaw
                {
                    Id           = e.Id.ToString(),
                    Name         = e.GetAttributeValue<string>("name"),
                    Category     = e.GetAttributeValue<OptionSetValue>("category")?.Value ?? 0,
                    PrimaryEntity = e.GetAttributeValue<string>("primaryentity"),
                    TriggerOnCreate = e.GetAttributeValue<bool>("triggeroncreate") ? 1 : 0,
                    TriggerOnDelete = e.GetAttributeValue<bool>("triggerondelete") ? 1 : 0,
                    TriggerOnUpdateAttributeList =
                        e.GetAttributeValue<string>("triggeronupdateattributelist"),
                    IsActive     = e.GetAttributeValue<OptionSetValue>("statecode")?.Value == 1
                }));

                query.PageInfo.PageNumber++;
                query.PageInfo.PagingCookie = response.PagingCookie;
            }
            while (response.MoreRecords);

            // Phase 2: fetch XAML in batches via ExecuteMultipleRequest
            FetchXamlInBatches(workflows);

            return workflows;
        }

        private void FetchXamlInBatches(List<ClassicWorkflowRaw> workflows)
        {
            int total = workflows.Count;
            int fetched = 0;

            for (int i = 0; i < total; i += XamlBatchSize)
            {
                var batch = workflows.Skip(i).Take(XamlBatchSize).ToList();

                var multiRequest = new ExecuteMultipleRequest
                {
                    Requests = new OrganizationRequestCollection(),
                    Settings = new ExecuteMultipleSettings
                    {
                        ContinueOnError = true,
                        ReturnResponses = true
                    }
                };

                foreach (var wf in batch)
                {
                    multiRequest.Requests.Add(new RetrieveRequest
                    {
                        Target    = new EntityReference("workflow", new Guid(wf.Id)),
                        ColumnSet = new ColumnSet("xaml")
                    });
                }

                var multiResponse = (ExecuteMultipleResponse)_serviceClient.Execute(multiRequest);

                for (int j = 0; j < batch.Count; j++)
                {
                    var item = multiResponse.Responses[j];
                    if (item.Response is RetrieveResponse retrieveResponse)
                        batch[j].XamlDefinition = retrieveResponse.Entity.GetAttributeValue<string>("xaml");
                }

                fetched += batch.Count;
                Console.Write(string.Format("\r  Fetching XAML: {0}/{1}...", fetched, total));
            }

            Console.WriteLine();
        }
    }
}
