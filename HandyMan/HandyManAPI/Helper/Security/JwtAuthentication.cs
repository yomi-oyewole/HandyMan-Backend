using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace HandyManAPI.Helper.Security
{
    public class JwtAuthentication : Attribute, IAuthenticationFilter
    {
        public bool AllowMultiple => false;
        public string Realm { get; set; }
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var request = context.Request;
            var authorization = request.Headers.Authorization;

            // checking request header value having required scheme "Bearer" or not.
            if (authorization == null || authorization.Scheme != "Bearer" ||
                string.IsNullOrEmpty(authorization.Parameter))
            {
                context.ErrorResult = new AuthFailureResult("Unauthorized", request);
                return;
            }

            // Getting Token value from header values.
            var token = authorization.Parameter;
            var principal = await AuthJwtToken(token);

            if(principal== null)
                context.ErrorResult = new AuthFailureResult("Unauthorized", request);
            else
            {
                context.Principal = principal;
            }
        }

        private static bool ValidadateToken(string token, out string userId)
        {
            userId = null;

            var simplePrinciple = TokenProvider.GetPrincipal(token);
            if (simplePrinciple == null)
                return false;
            var identity = simplePrinciple.Identity as ClaimsIdentity;

            if (identity == null)
                return false;

            if (!identity.IsAuthenticated)
                return false;
            

            var userIdClaim = identity.FindFirst(ClaimTypes.Name);
            userId = userIdClaim.Value;

            if (string.IsNullOrEmpty(userId))
                return false;

            return true;
        }

        protected Task<IPrincipal> AuthJwtToken(string token)
        {
            string userId;
            if (ValidadateToken(token, out userId))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userId)
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return Task.FromResult(user);
            }
            return Task.FromResult<IPrincipal>(null);

        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            Challenge(context);
            return Task.FromResult(0);
        }

        private void Challenge(HttpAuthenticationChallengeContext context)
        {
            string parameter = null;

            if (!string.IsNullOrEmpty(Realm))
                parameter = "realm=\"" + Realm + "\"";

          context.ChallengeWith("Bearer", parameter);

            
        }
    }

    public static class HttpAuthenticationChallengeContextExtensions
    {
        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme));
        }

        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, string scheme, string parameter)
        {
            ChallengeWith(context, new AuthenticationHeaderValue(scheme, parameter));
        }

        public static void ChallengeWith(this HttpAuthenticationChallengeContext context, AuthenticationHeaderValue challenge)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.Result = new UnauthorizedResult(challenge, context.Result);
        }
    }
}