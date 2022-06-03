using System;
using System.Collections.Generic;
using System.Text;
using TheComfortZone.DTO.Utils;

namespace TheComfortZone.DTO.User
{
    public class UserSearchRequest : BaseSearchObject
    {
        public string RoleName { get; set; }
        public string Username { get; set; }
    }
}
