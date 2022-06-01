using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class MetricUnitController : BaseReadController<DTO.MetricUnit.MetricUnitResponse, BaseSearchObject>
    {
        private readonly IMetricUnitService metricUnitService;
        public MetricUnitController(IMetricUnitService service) : base(service)
        {
            metricUnitService = service;
        }
    }
}
