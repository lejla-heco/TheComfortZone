using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class FurnitureColor
    {
        public int FurnitureColorId { get; set; }
        public int ColorId { get; set; }
        public int FurnitureItemId { get; set; }

        public virtual Color Color { get; set; } = null!;
        public virtual FurnitureItem FurnitureItem { get; set; } = null!;
    }
}
