using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.DTO.FurnitureItem
{
    public class FurnitureItemSearchRequest : BaseSearchObject
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string State { get; set; }
    }
}
