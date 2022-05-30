using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Designer
    {
        public Designer()
        {
            Appointments = new HashSet<Appointment>();
            Collections = new HashSet<Collection>();
        }

        public int DesignerId { get; set; }
        public string Name { get; set; } = null!;
        public float ConsultationPrice { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }
    }
}
