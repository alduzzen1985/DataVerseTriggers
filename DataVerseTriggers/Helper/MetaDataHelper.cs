using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;

namespace DataVerseTrigger.Helper
{
    public class MetaDataHelper
    {
        public static EntityMetadata[] GetListEntities(IOrganizationService service)
        {
            MetadataPropertiesExpression EntityProperties = new MetadataPropertiesExpression()
            {
                AllProperties = false
            };
            EntityProperties.PropertyNames.AddRange(new string[] { "DisplayName", "LogicalName", "ObjectTypeCode" });


            MetadataFilterExpression EntityFilter = new MetadataFilterExpression(LogicalOperator.And);
            EntityFilter.Conditions.Add(new MetadataConditionExpression("IsIntersect", MetadataConditionOperator.Equals, false));

            EntityQueryExpression entityQueryExpression = new EntityQueryExpression()
            {
                Properties = EntityProperties,
            };

            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest()
            {
                Query = entityQueryExpression
            };


            var response = (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);

            return response.EntityMetadata.ToArray();

        }



        public static AttributeMetadata[] GetListFieldsForEntity(IOrganizationService service, string entityLogicalName)
        {
            MetadataFilterExpression EntityFilter = new MetadataFilterExpression(LogicalOperator.And);
            EntityFilter.Conditions.Add(new MetadataConditionExpression("LogicalName", MetadataConditionOperator.Equals, entityLogicalName));
            EntityQueryExpression entityQueryExpression = new EntityQueryExpression()
            {
                Criteria = EntityFilter,
            };
            RetrieveMetadataChangesResponse initialRequest = GetMetadataChanges(service, entityQueryExpression, null, DeletedMetadataFilters.All);
            return initialRequest.EntityMetadata.Any() ? initialRequest.EntityMetadata[0].Attributes : null;

        }






        private static RetrieveMetadataChangesResponse GetMetadataChanges(IOrganizationService service, EntityQueryExpression entityQueryExpression, String clientVersionStamp, DeletedMetadataFilters deletedMetadataFilter)
        {
            RetrieveMetadataChangesRequest retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest()
            {
                Query = entityQueryExpression,
                ClientVersionStamp = clientVersionStamp,
                DeletedMetadataFilters = deletedMetadataFilter
            };
            return (RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest);
        }




    }
}
