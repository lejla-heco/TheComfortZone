using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TheComfortZone.DTO.Space;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class SpaceController : BaseCRUDController<SpaceResponse, BaseSearchObject, SpaceUpsertRequest, SpaceUpsertRequest>
    {
        private readonly ISpaceService spaceService;

        public SpaceController(ISpaceService service) : base(service)
        {
            spaceService = service;
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override async Task<SpaceResponse> Insert([FromBody] SpaceUpsertRequest insert)
        {
            return await base.Insert(insert);
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override async Task<SpaceResponse> Update(int id, [FromBody] SpaceUpsertRequest update)
        {
            return await base.Update(id, update);
        }

        [NonAction]
        public override async Task<string> Delete(int id)
        {
            return await base.Delete(id);
        }

        [HttpGet("spaces-with-categories")]
        public async Task<List<DTO.Space.SpaceResponse>> GetSpacesWithCategoryData()
        {
            return await spaceService.GetSpacesWithCategoryData();
        }
    }
}
