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

        [HttpGet("spaces-with-categories")]
        public async Task<List<DTO.Space.SpaceResponse>> GetSpacesWithCategoryData()
        {
            return await spaceService.GetSpacesWithCategoryData();
        }
    }
}
