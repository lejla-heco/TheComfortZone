using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.OrderItem;

namespace TheComfortZone.WINUI.Service
{
    public class OrderItemAPIService : BaseReadAPIService<OrderItemResponse, OrderItemSearchRequest>
    {
        private const string API_ROUTE = "OrderItem";
        public OrderItemAPIService() : base(API_ROUTE)
        {
        }
    }
}
