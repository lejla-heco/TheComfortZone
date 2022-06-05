using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.DTO.FurnitureItem
{
    public class FurnitureItemSearchRequest : BaseSearchObject
    {
        [MaxLength(60)]
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public string State { get; set; }
    }
}
