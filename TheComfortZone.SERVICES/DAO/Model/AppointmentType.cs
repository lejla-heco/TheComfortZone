using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class AppointmentType
    {
        public AppointmentType()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int AppointmentTypeId { get; set; }
        public string Name { get; set; } = null!;
        public byte[]? Description { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
