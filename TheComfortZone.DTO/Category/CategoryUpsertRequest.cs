using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheComfortZone.DTO.Category
{
    public class CategoryUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        public int SpaceId { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
