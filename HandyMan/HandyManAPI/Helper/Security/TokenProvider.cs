using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using HandyManAPI.DataContext;
using HandyManAPI.Models;
using HandyManAPI.Persistence.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace HandyManAPI.Helper.Security
{
    public class TokenProvider
    {

        public static string GetToken(User user)
        {
            var loginRep = new LoginRepository(new HandyManContext());
            var authenticatedUser = loginRep.Authenticate(user.Email, user.Password);

            if(authenticatedUser == null)
                throw new ArgumentException("Invalid User", "user");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("appsetting secret should be heere");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()), 
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}