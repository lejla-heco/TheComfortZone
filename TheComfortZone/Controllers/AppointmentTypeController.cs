using TheComfortZone.DTO.Color;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class AppointmentTypeController : BaseReadController<DTO.AppointmentType.AppointmentTypeResponse, BaseSearchObject>
    {
        private readonly IAppointmentTypeService appointmentTypeService;
        public AppointmentTypeController(IAppointmentTypeService service) : base(service)
        {
            appointmentTypeService = service;
        }
    }
}
