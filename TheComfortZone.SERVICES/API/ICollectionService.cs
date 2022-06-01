using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface ICollectionService : ICRUDService<DTO.Collection.CollectionResponse, BaseSearchObject, DTO.Collection.CollectionUpsertRequest, DTO.Collection.CollectionUpsertRequest>
    {
        public Task<List<DTO.Collection.CollectionResponse>> GetCollectionsByDesignerId(int id);
    }
}
