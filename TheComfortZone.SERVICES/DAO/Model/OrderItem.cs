using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int FurnitureItemId { get; set; }
        public int OrderId { get; set; }
        public int? OrderQuantity { get; set; }

        public virtual FurnitureItem FurnitureItem { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
