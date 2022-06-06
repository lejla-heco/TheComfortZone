﻿using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "User")]
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
    }
}
