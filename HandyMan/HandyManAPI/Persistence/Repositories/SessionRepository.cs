using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HandyManAPI.Core.Repositories;
using HandyManAPI.DataContext;
using HandyManAPI.Helper.Security;
using HandyManAPI.Models;


namespace HandyManAPI.Persistence.Repositories
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(DbContext context) : base(context)
        {
        }

        public HandyManContext HmContext => Context as HandyManContext;


        public void CreateSession(User user)
        {
            string token = TokenProvider.GetToken(user);
            using (var unitOfWork = new UnitOfWork(HmContext))
            {

                var session = new Session
                {
                    User = user,
                    Token = token,
                    UserId =user.UserId
                    
                };

                

                unitOfWork.Session.Add(session);
                unitOfWork.Complete();

            }

        }
    }
}