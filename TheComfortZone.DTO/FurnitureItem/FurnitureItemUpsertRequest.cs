using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheComfortZone.DTO.FurnitureItem
{
    public class FurnitureItemUpsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int CollectionId { get; set; }
        [Required]
        public int MaterialId { get; set; }
        [Required]
        public float RegularPrice { get; set; }
        [Required]
        public float DiscountPrice { get; set; }
        public bool? OnSale { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public string State { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public int MetricUnitId { get; set; }
        [Required]
        public int InStockQuantity { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public string Width { get; set; }
        [Required]
        public List<int> ColorIdList { get; set; } = new List<int> { };

    }
}
