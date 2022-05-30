using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.Color;

namespace TheComfortZone.DTO.FurnitureColor
{
    public class FurnitureColorResponse
    {
        public int FurnitureColorId { get; set; }
        public int ColorId { get; set; }
        public int FurnitureId { get; set; }
        public virtual ColorResponse Color { get; set; } 
    }
}
