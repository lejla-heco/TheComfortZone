using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Coupon
{
    public class CouponResponse
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int Discount { get; set; }
        public bool? Active { get; set; }
        public string Customer { get; set; }
    }
}
