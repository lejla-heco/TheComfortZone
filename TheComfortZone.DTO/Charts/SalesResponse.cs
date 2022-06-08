using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Charts
{
    public class SalesResponse
    {
        public string Customer { get; set; }
        public string Employee { get; set; }
        public DateTime Date { get; set; }
        public int TotalPrice { get; set; }
    }
}
