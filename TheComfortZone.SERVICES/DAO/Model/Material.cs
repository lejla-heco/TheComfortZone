using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Material
    {
        public Material()
        {
            FurnitureItems = new HashSet<FurnitureItem>();
        }

        public int MaterialId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<FurnitureItem> FurnitureItems { get; set; }
    }
}
