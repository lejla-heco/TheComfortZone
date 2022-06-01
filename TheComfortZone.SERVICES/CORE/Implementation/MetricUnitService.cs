using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.DAO;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class MetricUnitService : BaseReadService<DTO.MetricUnit.MetricUnitResponse, DAO.Model.MetricUnit, BaseSearchObject>, IMetricUnitService
    {
        public MetricUnitService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
