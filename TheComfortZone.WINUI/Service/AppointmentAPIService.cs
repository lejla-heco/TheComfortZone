using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Appointment;

namespace TheComfortZone.WINUI.Service
{
    public class AppointmentAPIService : BaseAPIService<AppointmentResponse, AppointmentSearchRequest, AppointmentInsertRequest, AppointmentUpdateRequest>
    {
        private const string API_ROUTE = "Appointment";
        public AppointmentAPIService() : base(API_ROUTE)
        {
        }
    }
}
