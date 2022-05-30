using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using TheComfortZone.DTO.Utils;
using TheComfortZone.SERVICES.API;
using TheComfortZone.Utils;

namespace TheComfortZone.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public IUserService UserService { get; set; }
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IUserService UserService) : base(options, logger, encoder, clock)
        {
            this.UserService = UserService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing auth header");
            }

            Credentials credentials = CredentialsParser.ParseCredentials(Request);

            var user = await UserService.Login(credentials.Username, credentials.Password);

            if (user == null)
                return AuthenticateResult.Fail("Incorrect username or password");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, credentials.Username),
                new Claim(ClaimTypes.Name, user.FirstName)
            };

            
            claims.Add(new Claim(ClaimTypes.Role, user.Role.Name));
            

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
