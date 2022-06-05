using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Status { get; set; }
        public int OrderNumber { get; set; }
        public int? Noip { get; set; }
        public float? TotalPrice { get; set; }
        public bool? UsedDiscountCoupon { get; set; }
        public int UserId { get; set; }
        public bool? CurrentOrder { get; set; }
        public int? EmployeeId { get; set; }

        public virtual User? Employee { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
