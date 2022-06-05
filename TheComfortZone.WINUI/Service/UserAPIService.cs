using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheComfortZone.WINUI.Utils;
using TheComfortZone.DTO.Utils;
using TheComfortZone.DTO.User;

namespace TheComfortZone.WINUI.Service
{
    public class UserAPIService : BaseAPIService<DTO.User.UserResponse, DTO.User.UserSearchRequest, DTO.User.UserInsertRequest, DTO.User.UserUpdateRequest>
    {
        private const string API_ROUTE = "User";
        public UserAPIService() : base(API_ROUTE)
        {
        }

        public async Task<string> GetUserRole()
        {
            try
            {
                return await new Uri(endpoint)
                        .AppendPathSegment(resource)
                        .AppendPathSegment("user-role")
                        .WithBasicAuth(CredentialHelper.Username, CredentialHelper.Password)
                        .GetStringAsync();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, dynamic>>();
                return ExceptionHandler.HandleException<string>(errors);
            }
        }
    }
}
