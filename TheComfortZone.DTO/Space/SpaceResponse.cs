using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.Space
{
    public class SpaceResponse
    {

        public int SpaceId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
    }
}
