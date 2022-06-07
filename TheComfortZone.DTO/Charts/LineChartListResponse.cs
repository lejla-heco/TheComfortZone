using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Charts
{
    public class LineChartListResponse
    {
        public string FurnitureName { get; set; }
        public List<LineChartResponse> ChartData { get; set; } = new List<LineChartResponse>();
    }
}
