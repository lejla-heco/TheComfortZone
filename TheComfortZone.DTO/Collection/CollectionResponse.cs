using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.Designer;

namespace TheComfortZone.DTO.Collection
{
    public class CollectionResponse
    {
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public int DesignerId { get; set; }
        public virtual DesignerResponse Designer { get; set; }
        public string DesignerName => Designer?.Name;
    }
}
