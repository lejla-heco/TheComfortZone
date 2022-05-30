using System;
using System.Collections.Generic;

namespace TheComfortZone.SERVICES.DAO.Model
{
    public partial class User
    {
        public User()
        {
            Appointments = new HashSet<Appointment>();
            Coupons = new HashSet<Coupon>();
            Favourites = new HashSet<Favourite>();
            Orders = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string? Username { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
