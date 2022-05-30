using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class FurnitureItem
    {
        public FurnitureItem()
        {
            Favourites = new HashSet<Favourite>();
            FurnitureColors = new HashSet<FurnitureColor>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int FurnitureItemId { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public int CollectionId { get; set; }
        public int MaterialId { get; set; }
        public float RegularPrice { get; set; }
        public float DiscountPrice { get; set; }
        public bool? OnSale { get; set; }
        public byte[] Image { get; set; } = null!;
        public string? State { get; set; }
        public string? Description { get; set; }
        public bool? Favourited { get; set; }
        public int MetricUnitId { get; set; }
        public int InStockQuantity { get; set; }
        public string Height { get; set; } = null!;
        public string Width { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual Collection Collection { get; set; } = null!;
        public virtual Material Material { get; set; } = null!;
        public virtual MetricUnit MetricUnit { get; set; } = null!;
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<FurnitureColor> FurnitureColors { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
