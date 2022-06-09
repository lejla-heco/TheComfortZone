using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Charts;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles = "Administrator")]
    public class ChartController : ControllerBase
    {
        public readonly IChartService chartService;

        public ChartController(IChartService service)
        {
            this.chartService = service;
        }

        [HttpGet("best-selling-items/{space}")]
        public async Task<List<LineChartListResponse>> GetBestSellingItems(string space)
        {
            return await chartService.GetBestSellingItems(space);
        }

        [HttpGet("sales-by-period")]
        public async Task<List<SalesResponse>> GetSalesByPeriod([FromQuery] DateRangeSearchRequest search = null)
        {
            return await chartService.GetSalesByPeriod(search);
        }

        [HttpGet("income-per-employee")]
        public async Task<List<PieChartEmployeeResponse>> GetIncomePerEmployee([FromQuery] DateRangeSearchRequest search = null)
        {
            return await chartService.GetIncomePerEmployee(search);
        }

        [HttpGet("loyal-customers")]
        public async Task<List<PieChartCustomerResponse>> GetLoyalCustomers()
        {
            return await chartService.GetLoyalCustomers();
        }
    }
}
