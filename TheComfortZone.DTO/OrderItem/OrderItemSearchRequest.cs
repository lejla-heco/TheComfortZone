using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.DTO.OrderItem
{
    public class OrderItemSearchRequest : BaseSearchObject
    {
        public int? OrderId { get; set; }
    }
}
