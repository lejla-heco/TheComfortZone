using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Charts
{
    public class DateRangeSearchRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
