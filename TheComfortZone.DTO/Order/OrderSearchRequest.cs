using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.DTO.Order
{
    public class OrderSearchRequest : BaseSearchObject
    {
        public int? EmployeeId { get; set; }
        public int? UserId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
