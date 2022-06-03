using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class MetricUnitAPIService : BaseAPIService<DTO.MetricUnit.MetricUnitResponse, BaseSearchObject, DTO.MetricUnit.MetricUnitUpsertRequest, DTO.MetricUnit.MetricUnitUpsertRequest>
    {
        private const string API_ROUTE = "MetricUnit";
        public MetricUnitAPIService() : base(API_ROUTE)
        {
        }
    }
}
