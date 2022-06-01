using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Designer;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class DesignerController : BaseCRUDController<DesignerResponse, BaseSearchObject, DesignerUpsertRequest, DesignerUpsertRequest>
    {
        private readonly IDesignerService designerService;

        public DesignerController(IDesignerService service) : base(service)
        {
            designerService = service;
        }

        [HttpGet("designers-with-collections")]
        public async Task<List<DTO.Designer.DesignerResponse>> GetDesignersWithCollectionData()
        {
            return await designerService.GetDesignersWithCollectionData();
        }
    }
}
