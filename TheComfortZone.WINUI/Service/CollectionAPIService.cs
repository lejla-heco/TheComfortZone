using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Collection;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class CollectionAPIService : BaseAPIService<DTO.Collection.CollectionResponse, BaseSearchObject, DTO.Collection.CollectionUpsertRequest, DTO.Collection.CollectionUpsertRequest>
    {
        private const string API_ROUTE = "Collection";
        public CollectionAPIService() : base(API_ROUTE)
        {
        }

        public async Task<List<CollectionResponse>> GetCollectionsByDesignerId(int id)
        {
            try
            {
                return await new Uri(endpoint)
                    .AppendPathSegments(resource, "collections-by-designer-id", id)
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<CollectionResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<CollectionResponse>>(errors);
            }
        }
    }
}
