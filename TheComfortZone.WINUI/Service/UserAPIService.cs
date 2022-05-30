using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Service
{
    public class UserAPIService : BaseAPIService<DTO.User.UserResponse, object, DTO.User.UserUpsertRequest, DTO.User.UserUpsertRequest>
    {
        public UserAPIService() : base("User")
        {
        }

        public async Task<string> GetUserRole()
        {
            return await new Uri(endpoint)
                    .AppendPathSegment(resource)
                    .AppendPathSegment("user-role")
                    .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                    .GetStringAsync();
        }

    }
}
