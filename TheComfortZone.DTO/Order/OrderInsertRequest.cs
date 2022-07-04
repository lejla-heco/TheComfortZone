using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.OrderItem;

namespace TheComfortZone.DTO.Order
{
    public class OrderInsertRequest
    {
        public int UserId { get; set; }
        public int? CouponId { get; set; }
        public List<OrderItemInsertRequest> items { get; set; }
    }
}
