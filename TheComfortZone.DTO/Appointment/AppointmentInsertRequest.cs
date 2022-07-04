using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Appointment
{
    public class AppointmentInsertRequest
    {
        public DateTime AppointmentDate { get; set; }
        public int Duration { get; set; }
        public float TotalPrice { get; set; }
        public int UserId { get; set; }
        public int DesignerId { get; set; }
        public int AppointmentTypeId { get; set; }

    }
}
