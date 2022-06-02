using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Space
{
    public class SpaceUpsertRequest
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
