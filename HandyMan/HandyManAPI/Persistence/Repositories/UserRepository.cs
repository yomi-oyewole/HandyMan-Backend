using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HandyManAPI.Core.Repositories;
using HandyManAPI.DataContext;
using HandyManAPI.Models;

namespace HandyManAPI.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(HandyManContext context) : base(context)
        {
        }


        public HandyManContext HmContext => Context as HandyManContext;
    }
}