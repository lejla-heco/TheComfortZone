using TheComfortZone.DTO.Material;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class MaterialController : BaseReadController<DTO.Material.MaterialResponse, BaseSearchObject>
    {
        private readonly IMaterialService materialService;
        public MaterialController(IMaterialService service) : base(service)
        {
            materialService = service;
        }
    }
}
