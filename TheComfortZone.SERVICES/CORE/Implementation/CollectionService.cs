using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Collection;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class CollectionService : BaseCRUDService<DTO.Collection.CollectionResponse, DAO.Model.Collection, BaseSearchObject, DTO.Collection.CollectionUpsertRequest, DTO.Collection.CollectionUpsertRequest>, ICollectionService
    {
        public CollectionService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<CollectionResponse>> GetCollectionsByDesignerId(int id)
        {
            if (context.Designers.FirstOrDefault(d => d.DesignerId == id) == null)
            {
                throw new UserException("Designer with specified ID does not exist!");
            }
            var entities = context.Collections.Where(c => c.DesignerId == id);
            return mapper.Map<List<CollectionResponse>>(entities.ToList());
        }
    }
}
