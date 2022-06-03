using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Space;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class SpaceService : BaseCRUDService<DTO.Space.SpaceResponse, DAO.Model.Space, BaseSearchObject, DTO.Space.SpaceUpsertRequest, DTO.Space.SpaceUpsertRequest>, ISpaceService
    {
        public SpaceService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<SpaceResponse>> GetSpacesWithCategoryData()
        {
            var entities = context.Spaces.Where(s => s.Categories.Count != 0);
            return mapper.Map<List<SpaceResponse>>(entities.ToList());
        }

        /** VALIDATION **/
        public override void ValidateUpdate(int id, SpaceUpsertRequest update)
        {
            if (context.Spaces.Find(id) == null)
                throw new UserException("Space with specified ID does not exist!");
        }
    }
}
