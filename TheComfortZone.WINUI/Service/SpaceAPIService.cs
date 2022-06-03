using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Space;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class SpaceAPIService : BaseAPIService<SpaceResponse, BaseSearchObject, SpaceUpsertRequest, SpaceUpsertRequest>
    {
        private const string API_ROUTE = "Space";
        public SpaceAPIService() : base(API_ROUTE)
        {
        }
        public async Task<List<SpaceResponse>> GetSpacesWithCateroryData()
        {
            try
            {
                return await new Uri(endpoint)
                    .AppendPathSegments(resource, "spaces-with-categories")
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<SpaceResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<SpaceResponse>>(errors);
            }
        }

    }
}
