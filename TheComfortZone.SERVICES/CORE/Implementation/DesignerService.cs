using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Designer;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.SERVICES.CORE.Utils;
using TheComfortZone.SERVICES.DAO;

namespace TheComfortZone.SERVICES.CORE.Implementation
{
    public class DesignerService : BaseCRUDService<DTO.Designer.DesignerResponse, DAO.Model.Designer, BaseSearchObject, DTO.Designer.DesignerUpsertRequest, DTO.Designer.DesignerUpsertRequest>, IDesignerService
    {
        public DesignerService(TheComfortZoneContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<DesignerResponse>> GetDesignersWithCollectionData()
        {
            var entities = context.Designers.Where(s => s.Collections.Count != 0);
            return mapper.Map<List<DesignerResponse>>(entities.ToList());
        }

        /** VALIDATION **/
        public override void ValidateUpdate(int id, DesignerUpsertRequest update)
        {
            if (context.Designers.Find(id) == null)
                throw new UserException("Designer with specified ID does not exist!");
        }
    }
}
