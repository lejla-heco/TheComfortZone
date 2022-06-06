using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.AppointmentType;
using TheComfortZone.DTO.Designer;

namespace TheComfortZone.DTO.Appointment
{
    public class AppointmentResponse
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int Duration { get; set; }
        public float TotalPrice { get; set; }
        public bool? Approved { get; set; }
        public int UserId { get; set; }
        public int DesignerId { get; set; }
        public int AppointmentTypeId { get; set; }
        public string Customer { get; set; }

        /** RELATIONSHIPHS **/
        public virtual AppointmentTypeResponse AppointmentType { get; set; }
        public virtual DesignerResponse Designer { get; set; }

        /** CALCULATED FIELDS **/
        public string DesignerName => Designer?.Name;
        public string Type => AppointmentType?.Name;
        public bool? Declined => Approved == null ? null : !Approved;

    }
}
