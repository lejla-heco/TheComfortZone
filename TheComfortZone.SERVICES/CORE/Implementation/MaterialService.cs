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
    public class MaterialService : BaseReadService<DTO.Material.MaterialResponse, DAO.Model.Material, BaseSearchObject>, IMaterialService
    {
        public MaterialService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
