using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Administrator")]
        public async override Task<DesignerResponse> Insert([FromBody] DesignerUpsertRequest insert)
        {
            return await base.Insert(insert);
        }

        [Authorize(Roles = "Administrator")]
        public async override Task<DesignerResponse> Update(int id, [FromBody] DesignerUpsertRequest update)
        {
            return await base.Update(id, update);
        }

        [NonAction]
        public async override Task<string> Delete(int id)
        {
            return await base.Delete(id);
        }

        [HttpGet("designers-with-collections")]
        public async Task<List<DTO.Designer.DesignerResponse>> GetDesignersWithCollectionData()
        {
            return await designerService.GetDesignersWithCollectionData();
        }
    }
}
