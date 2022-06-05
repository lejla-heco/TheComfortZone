using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheComfortZone.DTO.User
{
    public class UserInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(70)]
        public string Adress { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(15)]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(30)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string PasswordConfirmation { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MaxLength(10)]
        public string RoleName { get; set; }
    }
}
