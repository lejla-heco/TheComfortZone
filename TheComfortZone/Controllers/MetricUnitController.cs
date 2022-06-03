using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class MetricUnitController : BaseCRUDController<DTO.MetricUnit.MetricUnitResponse, BaseSearchObject, DTO.MetricUnit.MetricUnitUpsertRequest, DTO.MetricUnit.MetricUnitUpsertRequest>
    {
        private readonly IMetricUnitService metricUnitService;
        public MetricUnitController(IMetricUnitService service) : base(service)
        {
            metricUnitService = service;
        }
    }
}
