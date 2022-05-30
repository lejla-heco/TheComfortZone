using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using TheComfortZone.DTO.User;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.Utils;

namespace TheComfortZone.Controllers
{
    public class UserController : BaseCRUDController<UserResponse, BaseSearchObject, UserUpsertRequest, UserUpsertRequest>
    {
        public readonly IUserService userService;
        public UserController(IUserService service) : base(service)
        {
            this.userService = service;
        }

        [Authorize(Roles = "Administrator")]
        public override UserResponse Insert([FromBody] UserUpsertRequest insert)
        {
            return base.Insert(insert);
        }

        [HttpGet("user-role")]
        public Task<string> GetUserRole()
        {
            Credentials credentials = CredentialsParser.ParseCredentials(Request);
            return userService.GetUserRole(credentials.Username, credentials.Password);
        }
    }
}
