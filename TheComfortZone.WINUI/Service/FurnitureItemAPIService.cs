using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.FurnitureItem;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class FurnitureItemAPIService : BaseAPIService<FurnitureItemResponse, FurnitureItemSearchRequest, FurnitureItemUpsertRequest, FurnitureItemUpsertRequest>
    {
        private const string API_ROUTE = "FurnitureItem";
        public FurnitureItemAPIService() : base(API_ROUTE)
        {
        }
        public async Task<List<DTO.Charts.LineChartListResponse>> GetLineChartData(string space)
        {
            try
            {
                return await new Uri(endpoint)
                    .AppendPathSegments(resource, "best-selling-items", space)
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<DTO.Charts.LineChartListResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<DTO.Charts.LineChartListResponse>>(errors);
            }
        }
    }
}
