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
        private readonly IUserService userService;
        public UserController(IUserService service) : base(service)
        {
            this.userService = service;
        }

        [Authorize(Roles = "Administrator")]
        public override UserResponse Insert([FromBody] UserUpsertRequest insert)
        {
            return base.Insert(insert);
        }

        [Authorize(Roles = "Administrator,User")]
        public override UserResponse Update(int id, [FromBody] UserUpsertRequest update)
        {
            return base.Update(id, update);
        }

        [HttpGet("user-role")]
        public Task<string> GetUserRole()
        {
            Credentials credentials = CredentialsParser.ParseCredentials(Request);
            return userService.GetUserRole(credentials.Username, credentials.Password);
        }
    }
}
