using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheComfortZone.DTO.Space
{
    public class SpaceUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
