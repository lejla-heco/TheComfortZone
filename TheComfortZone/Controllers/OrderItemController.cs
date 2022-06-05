using TheComfortZone.DTO.OrderItem;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class OrderItemController : BaseReadController<OrderItemResponse, OrderItemSearchRequest>
    {
        private readonly IOrderItemService orderItemService;
        public OrderItemController(IOrderItemService service) : base(service)
        {
            orderItemService = service;
        }
    }
}
