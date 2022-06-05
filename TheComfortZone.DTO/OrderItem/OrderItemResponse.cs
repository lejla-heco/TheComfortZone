using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.OrderItem
{
    public class OrderItemResponse
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CollectionName { get; set; }
        public float UnitPrice { get; set; }
        public int OrderQuantity { get; set; }
        public string Color { get; set; }
        public string MaterialName { get; set; }
    }
}
