using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class Favourite
    {
        public int FavouriteId { get; set; }
        public int FurnitureItemId { get; set; }
        public int UserId { get; set; }

        public virtual FurnitureItem FurnitureItem { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
