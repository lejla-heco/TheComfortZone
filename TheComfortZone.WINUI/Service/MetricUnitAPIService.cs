using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class MetricUnitAPIService : BaseReadAPIService<DTO.MetricUnit.MetricUnitResponse, BaseSearchObject>
    {
        private const string API_ROUTE = "MetricUnit";
        public MetricUnitAPIService() : base(API_ROUTE)
        {
        }
    }
}
