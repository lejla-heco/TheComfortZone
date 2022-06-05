using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Order
{
    public class OrderResponse
    {
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }
        public int OrderNumber { get; set; }
        public int? Noip { get; set; }
        public float? TotalPrice { get; set; }
        public bool? UsedDiscountCoupon { get; set; }
        public int? Discount { get; set; }

        /** CUSTOMER INFORMATION **/
        public string Customer { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
    }
}
