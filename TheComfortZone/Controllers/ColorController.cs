using TheComfortZone.DTO.Color;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class ColorController : BaseReadController<DTO.Color.ColorResponse, BaseSearchObject>
    {
        private readonly IColorService colorService;
        public ColorController(IColorService service) : base(service)
        {
            colorService = service;
        }
    }
}
