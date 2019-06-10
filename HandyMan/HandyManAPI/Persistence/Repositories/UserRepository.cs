using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HandyManAPI.Core;
using HandyManAPI.Core.Repositories;
using HandyManAPI.DataContext;
using HandyManAPI.Helper.Security;
using HandyManAPI.Models;

namespace HandyManAPI.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HandyManContext context) : base(context)
        {
        }


        public HandyManContext HmContext => Context as HandyManContext;

        public User Create(User user)
        {
            if(string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Password Required");
            if(HmContext.Users.Any(x => x.Email == user.Email))
                throw new ArgumentException($"Username: {user.Email} is already taken");

            byte[] passwordHash, passwordSalt;
            MembershipProvider.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);

            using (var unitOfWork = new UnitOfWork(new HandyManContext()))
            {
                unitOfWork.Users.Add(user);
                var loginModel = new Login
                {
                    User = user,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Email = user.Email,
                    
                };

                unitOfWork.Login.Add(loginModel);
                unitOfWork.Complete();
            }

            return user;
        }
        
    }
}