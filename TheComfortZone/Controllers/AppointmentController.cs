using TheComfortZone.DTO.Appointment;
using TheComfortZone.SERVICES.API;

namespace TheComfortZone.Controllers
{
    public class AppointmentController : BaseCRUDController<AppointmentResponse, AppointmentSearchRequest, AppointmentInsertRequest, AppointmentUpdateRequest>
    {
        private readonly IAppointmentService appointmentService;
        public AppointmentController(IAppointmentService service) : base(service)
        {
            appointmentService = service;
        }
    }
}
