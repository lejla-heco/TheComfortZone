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
        public override DesignerResponse Insert([FromBody] DesignerUpsertRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Administrator")]
        public override DesignerResponse Update(int id, [FromBody] DesignerUpsertRequest update)
        {
            return base.Update(id, update);
        }

        [NonAction]
        public override string Delete(int id)
        {
            return base.Delete(id);
        }

        [HttpGet("designers-with-collections")]
        public async Task<List<DTO.Designer.DesignerResponse>> GetDesignersWithCollectionData()
        {
            return await designerService.GetDesignersWithCollectionData();
        }
    }
}
