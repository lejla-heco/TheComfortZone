using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.DTO.Appointment
{
    public class AppointmentSearchRequest : BaseSearchObject
    {
        public DateTime? AppointmentDate { get; set; }
    }
}
