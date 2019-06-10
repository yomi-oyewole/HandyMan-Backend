using HandyManAPI.Core.Repositories;
using HandyManAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HandyManAPI.DataContext;
using HandyManAPI.Helper.Security;
using HandyManAPI.Migrations;

namespace HandyManAPI.Persistence.Repositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(HandyManContext context) : base(context)
        {
            
        }

        public HandyManContext HmContext => Context as HandyManContext;

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var loginContext = SingleOrDefault(x => x.Email == email);
            if (loginContext == null)
                return null;

            var user = HmContext.Users.Single(x => x.UserId.Equals(loginContext.UserId));

            if (!MembershipProvider.VerifyPasswordHash(user.Password, loginContext.PasswordHash,
                loginContext.PasswordSalt))
                return null;

            //Need to added token to the to the return body. here or in API

            return user;
        }
        
    }
}