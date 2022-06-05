using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Order;

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
    }
}
