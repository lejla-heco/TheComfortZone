using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.Space;

namespace TheComfortZone.DTO.Category
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int SpaceId { get; set; }
        public string Description { get; set; }
        public virtual SpaceResponse Space { get; set; }
        public string SpaceName => Space?.Name;
    }
}
