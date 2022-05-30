using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Collection
    {
        public Collection()
        {
            FurnitureItems = new HashSet<FurnitureItem>();
        }

        public int CollectionId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Created { get; set; }
        public int DesignerId { get; set; }

        public virtual Designer Designer { get; set; } = null!;
        public virtual ICollection<FurnitureItem> FurnitureItems { get; set; }
    }
}
