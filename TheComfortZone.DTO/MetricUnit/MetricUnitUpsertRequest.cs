using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheComfortZone.DTO.MetricUnit
{
    public class MetricUnitUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
