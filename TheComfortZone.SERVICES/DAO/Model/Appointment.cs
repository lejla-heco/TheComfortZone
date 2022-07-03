using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int Duration { get; set; }
        public float TotalPrice { get; set; }
        public bool? Approved { get; set; }
        public int UserId { get; set; }
        public int DesignerId { get; set; }
        public int AppointmentTypeId { get; set; }
        public int? EmployeeId { get; set; }
        public string AppointmentNumber { get; set; } = null!;

        public virtual AppointmentType AppointmentType { get; set; } = null!;
        public virtual Designer Designer { get; set; } = null!;
        public virtual User? Employee { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
