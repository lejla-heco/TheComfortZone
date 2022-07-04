using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.OrderItem
{
    public class OrderItemInsertRequest
    {
        public int FurnitureItemId { get; set; }
        public int OrderQuantity { get; set; }
        public float UnitPrice { get; set; }
        public string Color { get; set; }
    }
}
