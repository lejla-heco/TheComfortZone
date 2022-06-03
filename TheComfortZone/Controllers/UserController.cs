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
    public class UserController : BaseCRUDController<UserResponse, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>
    {
        private readonly IUserService userService;
        public UserController(IUserService service) : base(service)
        {
            this.userService = service;
        }

        [Authorize(Roles = "Administrator")]
        public override Task<IEnumerable<UserResponse>> Get([FromQuery] UserSearchRequest search = null)
        {
            return base.Get(search);
        }

        [Authorize(Roles = "Administrator")]
        public override async Task<UserResponse> Insert([FromBody] UserUpsertRequest insert)
        {
            return await base.Insert(insert);
        }

        [Authorize(Roles = "Administrator,User")]
        public override async Task<UserResponse> Update(int id, [FromBody] UserUpsertRequest update)
        {
            return await base.Update(id, update);
        }

        [HttpGet("user-role")]
        public Task<string> GetUserRole()
        {
            Credentials credentials = CredentialsParser.ParseCredentials(Request);
            return userService.GetUserRole(credentials.Username, credentials.Password);
        }
    }
}
