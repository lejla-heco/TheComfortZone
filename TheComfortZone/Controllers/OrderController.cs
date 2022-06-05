using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Order;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class OrderController : BaseCRUDController<OrderResponse, OrderSearchRequest, OrderInsertRequest, OrderUpdateRequest>
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService service) : base(service)
        {
            orderService = service;
        }

        [NonAction]
        public override async Task<string> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
