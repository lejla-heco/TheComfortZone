using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Space
    {
        public Space()
        {
            Categories = new HashSet<Category>();
        }

        public int SpaceId { get; set; }
        public string Name { get; set; } = null!;
        public byte[] Image { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
