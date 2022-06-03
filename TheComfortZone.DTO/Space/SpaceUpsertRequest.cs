using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheComfortZone.DTO.Space
{
    public class SpaceUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
    }
}
