using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Charts;

namespace TheComfortZone.SERVICES.API
{
    public interface IChartService
    {
        Task<List<LineChartListResponse>> GetBestSellingItems(string space);
        Task<List<DTO.Charts.SalesResponse>> GetSalesByPeriod(DateRangeSearchRequest search = null);
        Task<List<DTO.Charts.PieChartEmployeeResponse>> GetIncomePerEmployee(DateRangeSearchRequest search = null);
    }
}
