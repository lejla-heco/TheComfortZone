using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Appointment;

namespace TheComfortZone.SERVICES.API
{
    public interface IAppointmentService : ICRUDService<AppointmentResponse, AppointmentSearchRequest, AppointmentInsertRequest, AppointmentUpdateRequest>
    {
        Task<List<AppointmentResponse>> GetAppointmentsByEmployeeId(int id, AppointmentSearchRequest search = null);
        Task<List<AppointmentResponse>> GetAppointmentsByUserId(int id, AppointmentSearchRequest search = null);
    }
}
