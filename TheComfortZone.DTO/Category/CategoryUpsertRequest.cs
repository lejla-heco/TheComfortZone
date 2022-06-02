using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Category
{
    public class CategoryUpsertRequest
    {
        public string Name { get; set; }
        public int SpaceId { get; set; }
        public string Description { get; set; }
    }
}
