using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize(Roles = "Administrator")]
        public override async Task<IEnumerable<AppointmentResponse>> Get([FromQuery] AppointmentSearchRequest search = null)
        {
            return await base.Get(search);
        }

        public override async Task<AppointmentResponse> Insert([FromBody] AppointmentInsertRequest insert)
        {
            return await base.Insert(insert);
        }

        [Authorize(Roles = "Administrator,Employee")]
        public override async Task<AppointmentResponse> Update(int id, [FromBody] AppointmentUpdateRequest update)
        {
            return await base.Update(id, update);
        }

        [NonAction]
        public override async Task<string> Delete(int id)
        {
            return await base.Delete(id);
        }

        [Authorize(Roles = "Employee")]
        [HttpGet("appointments-by-employee/{id}")]
        public async Task<List<AppointmentResponse>> GetAppointmentsByEmployeeId(int id, [FromQuery] AppointmentSearchRequest search = null)
        {
            return await appointmentService.GetAppointmentsByEmployeeId(id, search);
        }

        [HttpGet("appointments-by-user/{id}")]
        public async Task<List<AppointmentResponse>> GetAppointmentsByUserId(int id, [FromQuery] AppointmentSearchRequest search = null)
        {
            return await appointmentService.GetAppointmentsByUserId(id, search);
        }
    }
}
