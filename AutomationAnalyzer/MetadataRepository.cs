using System.Collections.Generic;
using System.Linq;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace Automation_Analyzer
{
    public class MetadataRepository
    {
        private readonly ServiceClient _serviceClient;

        public MetadataRepository(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }

        // Fetches the full entity set name → logical name mapping from Dataverse.
        // Power Automate stores entity names as OData collection names (e.g. "accounts");
        // this map converts them to logical names (e.g. "account").
        public Dictionary<string, string> GetEntitySetToLogicalNameMap()
        {
            var request = new RetrieveAllEntitiesRequest
            {
                EntityFilters         = EntityFilters.Entity,
                RetrieveAsIfPublished = true
            };
            var response = (RetrieveAllEntitiesResponse)_serviceClient.Execute(request);
            return response.EntityMetadata
                .Where(e => !string.IsNullOrEmpty(e.EntitySetName))
                .ToDictionary(
                    e => e.EntitySetName,
                    e => e.LogicalName,
                    System.StringComparer.OrdinalIgnoreCase);
        }
    }
}
