using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Coupon
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; } = null!;
        public int Discount { get; set; }
        public int UserId { get; set; }
        public bool? Active { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
