using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TheComfortZone.DTO.User
{
    public class UserUpdateRequest
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
        [MaxLength(20)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string PasswordConfirmation { get; set; }
    }
}
