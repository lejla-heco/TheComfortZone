using System;
using System.Collections.Generic;
using System.Text;

namespace TheComfortZone.DTO.FurnitureItem
{
    public class FurnitureItemResponse
    {
        public int FurnitureItemId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int CollectionId { get; set; }
        public int MaterialId { get; set; }
        public float RegularPrice { get; set; }
        public float DiscountPrice { get; set; }
        public bool? OnSale { get; set; }
        public byte[] Image { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public bool? Favourited { get; set; }
        public int MetricUnitId { get; set; }
    }
}
