using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Coupon
{
    public class CouponInsertRequest
    {
        public int Discount { get; set; }
        public int UserId { get; set; }
    }
}
