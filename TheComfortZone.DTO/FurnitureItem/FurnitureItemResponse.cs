using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheComfortZone.DTO.Category;
using TheComfortZone.DTO.Collection;
using TheComfortZone.DTO.Color;
using TheComfortZone.DTO.FurnitureColor;
using TheComfortZone.DTO.Material;
using TheComfortZone.DTO.MetricUnit;

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
        public int MetricUnitId { get; set; }
        public int InStockQuantity { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public bool? Favourited { get; set; }

        public string CategoryName { get; set; }
        public string SpaceName { get; set; }
        public string CollectionName { get; set; }
        public string DesignerName { get; set; }
        public string Colors { get; set; }
        public string Material { get; set; }
        public int SpaceId { get; set; }
        public int DesignerId { get; set; }

        /** RELATIONSHIPS **/
        public virtual MetricUnitResponse MetricUnit { get; set; }

        /** CALCULATED FIELDS **/
        public float Price => OnSale == true ? DiscountPrice : RegularPrice;
        public string Dimensions => $"H: {Height} Q: {Width}";
        public string InStockQuantityString => $"{InStockQuantity} {MetricUnit?.Name}";
    }
}
