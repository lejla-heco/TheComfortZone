using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface IMetricUnitService : ICRUDService<DTO.MetricUnit.MetricUnitResponse, BaseSearchObject, DTO.MetricUnit.MetricUnitUpsertRequest, DTO.MetricUnit.MetricUnitUpsertRequest>
    {
    }
}
