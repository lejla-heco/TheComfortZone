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

        [Authorize(Roles = "Administrator")]
        public override async Task<IEnumerable<OrderResponse>> Get([FromQuery] OrderSearchRequest search = null)
        {
            return await base.Get(search);
        }

        [Authorize(Roles = "User")]
        public override async Task<OrderResponse> Insert([FromBody] OrderInsertRequest insert)
        {
            return await base.Insert(insert);
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override async Task<OrderResponse> Update(int id, [FromBody] OrderUpdateRequest update)
        {
            return await base.Update(id, update);
        }

        [NonAction]
        public override async Task<string> Delete(int id)
        {
            return await base.Delete(id);
        }

        [Authorize(Roles = "Employee")]
        [HttpGet("orders-by-employee/{id}")]
        public async Task<List<OrderResponse>> GetOrdersByEmployeeId(int id, [FromQuery] OrderSearchRequest search = null)
        {
            return await orderService.GetOrdersByEmployeeId(id, search);
        }
    }
}
