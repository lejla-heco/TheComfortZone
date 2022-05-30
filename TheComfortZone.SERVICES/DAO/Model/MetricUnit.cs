using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class MetricUnit
    {
        public MetricUnit()
        {
            FurnitureItems = new HashSet<FurnitureItem>();
        }

        public int MetricUnitId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<FurnitureItem> FurnitureItems { get; set; }
    }
}
