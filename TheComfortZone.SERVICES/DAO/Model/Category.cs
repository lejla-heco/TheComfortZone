using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Category
    {
        public Category()
        {
            FurnitureItems = new HashSet<FurnitureItem>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int SpaceId { get; set; }
        public string? Description { get; set; }

        public virtual Space Space { get; set; } = null!;
        public virtual ICollection<FurnitureItem> FurnitureItems { get; set; }
    }
}
