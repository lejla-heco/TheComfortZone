using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheComfortZone.DTO.Designer
{
    public class DesignerUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        [Range(10, 750)]
        public float ConsultationPrice { get; set; }
    }
}
