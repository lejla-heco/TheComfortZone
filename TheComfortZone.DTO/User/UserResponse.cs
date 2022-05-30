using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.DTO.Role;

namespace TheComfortZone.DTO.User
{
    public class UserResponse
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual RoleResponse Role { get; set; }
        public string UserType => Role?.Name;
    }
}
