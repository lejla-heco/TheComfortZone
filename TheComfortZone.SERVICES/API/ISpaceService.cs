using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface ISpaceService : ICRUDService<DTO.Space.SpaceResponse, BaseSearchObject, DTO.Space.SpaceUpsertRequest, DTO.Space.SpaceUpsertRequest>
    {
        public Task<List<DTO.Space.SpaceResponse>> GetSpacesWithCategoryData();
    }
}
