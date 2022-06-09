using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Order;
using TheComfortZone.WINUI.Utils;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class OrderAPIService : BaseAPIService<OrderResponse, OrderSearchRequest, OrderInsertRequest, OrderUpdateRequest>
    {
        private const string API_ROUTE = "Order";
        public OrderAPIService() : base(API_ROUTE)
        {
        }

        public Task GetOrdersByEmployeeId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderResponse>> GetOrdersByEmployeeId(int id, object search = null)
        {
            try
            {
                string url = new Uri(endpoint)
                    .AppendPathSegments(resource, "orders-by-employee", id);

                if (search != null)
                {
                    url += "?";
                    url += await search.ToQueryString();
                }

                return await url
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetJsonAsync<List<OrderResponse>>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<List<OrderResponse>>(errors);
            }
        }
    }
}
