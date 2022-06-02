using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheComfortZone.DTO.Collection
{
    public class CollectionUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public int DesignerId { get; set; }
    }
}
