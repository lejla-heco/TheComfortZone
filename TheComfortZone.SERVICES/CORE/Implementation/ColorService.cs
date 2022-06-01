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
    public class ColorService : BaseReadService<DTO.Color.ColorResponse, DAO.Model.Color, BaseSearchObject>, IColorService
    {
        public ColorService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
