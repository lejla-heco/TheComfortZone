using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
using TheComfortZone.SERVICES.DAO.Model;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class CollectionService : BaseCRUDService<DTO.Collection.CollectionResponse, DAO.Model.Collection, BaseSearchObject, DTO.Collection.CollectionUpsertRequest, DTO.Collection.CollectionUpsertRequest>, ICollectionService
    {
        public CollectionService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IQueryable<Collection> IncludeList(IQueryable<Collection> query)
        {
            return query.Include(c => c.Designer);
        }

        public async Task<List<CollectionResponse>> GetCollectionsByDesignerId(int id)
        {
            /** VALIDATION **/
            if (context.Designers.Find(id) == null)
                throw new UserException("Designer with specified ID does not exist!");

            var entities = context.Collections.Where(c => c.DesignerId == id);
            return mapper.Map<List<CollectionResponse>>(entities.ToList());
        }

        /** VALIDATION **/
        public override void ValidateInsert(CollectionUpsertRequest insert)
        {
            if (context.Designers.Find(insert.DesignerId) == null)
                throw new UserException("Designer with specified ID does not exist!");
        }
        public override void ValidateUpdate(int id, CollectionUpsertRequest update)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool exception = false;
            if (context.Collections.Find(id) == null)
            {
                exception = true;
                stringBuilder.Append("Collection with specified ID does not exist!\n");
            }
            if (context.Designers.Find(update.DesignerId) == null)
            {
                exception = true;
                stringBuilder.Append("Designer with specified ID does not exist!");
            }
            if (exception)
            {
                throw new UserException(stringBuilder.ToString());
            }
        }
    }
}
