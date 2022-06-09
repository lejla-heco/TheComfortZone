using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Charts
{
    public class PieChartCustomerResponse
    {
        public int UserId { get; set; }
        public string Customer { get; set; }
        public int NumberOfPurchases { get; set; }
        public int NumberOfAppointments { get; set; }
        public float AmountSpent { get; set; }
    }
}
