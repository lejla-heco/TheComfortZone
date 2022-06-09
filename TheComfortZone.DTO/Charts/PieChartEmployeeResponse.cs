using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Charts
{
    public class PieChartEmployeeResponse
    {
        public string Employee { get; set; }
        public int NumberOfSalesMade { get; set; }
        public int NumberOfAppointments { get; set; }
        public float Income { get; set; }
    }
}
