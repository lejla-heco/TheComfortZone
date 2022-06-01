using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.SERVICES.API
{
    public interface IDesignerService : ICRUDService<DTO.Designer.DesignerResponse, BaseSearchObject, DTO.Designer.DesignerUpsertRequest, DTO.Designer.DesignerUpsertRequest>
    {
        public Task<List<DTO.Designer.DesignerResponse>> GetDesignersWithCollectionData();
    }
}
