using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using HandyManAPI.DataContext;
using HandyManAPI.Models;
using HandyManAPI.Persistence;
using HandyManAPI.Persistence.Repositories;
using Microsoft.IdentityModel.Tokens;


namespace HandyManAPI.Helper.Security
{
    public class TokenProvider 
    {

        private readonly string _issuer = String.Empty;
        private const string secretKey = "appsetting secret should be heere";
        public TokenProvider(string issuer)
        {
            _issuer = issuer;
        }
        public static string GenerateJwtToken(User user)
        {
            User authenticatedUser;
            using (var unitOfWork = new UnitOfWork(new HandyManContext()))
            {
                 authenticatedUser = unitOfWork.Login.Authenticate(user.Email, user.Password);
                 unitOfWork.Dispose();
            }
            //var loginRep = new LoginRepository(new HandyManContext());
            //var authenticatedUser = loginRep.Authenticate(user.Email, user.Password);

            if (authenticatedUser == null)
                throw new ArgumentException("Invalid User", "user");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(5.0),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                //var symmetricKey = Convert.FromBase64String(secretKey);
                var key = Encoding.ASCII.GetBytes(secretKey);
                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)

                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);
                return principal;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        
    }
}