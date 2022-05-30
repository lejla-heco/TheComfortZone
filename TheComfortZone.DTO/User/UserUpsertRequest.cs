using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheComfortZone.DTO.User
{
    public class UserUpsertRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public int RoleId { get; set; }
    }
}
