using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Color
    {
        public Color()
        {
            FurnitureColors = new HashSet<FurnitureColor>();
        }

        public int ColorId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<FurnitureColor> FurnitureColors { get; set; }
    }
}
