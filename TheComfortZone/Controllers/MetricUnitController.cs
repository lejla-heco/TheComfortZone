using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.MetricUnit;
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

        [Authorize(Roles = "Administrator")]
        public override MetricUnitResponse Insert([FromBody] MetricUnitUpsertRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Administrator")]
        public override MetricUnitResponse Update(int id, [FromBody] MetricUnitUpsertRequest update)
        {
            return base.Update(id, update);
        }

        [NonAction]
        public override string Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
