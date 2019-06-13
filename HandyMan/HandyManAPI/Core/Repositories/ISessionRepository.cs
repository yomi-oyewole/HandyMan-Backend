using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyManAPI.Models;

namespace HandyManAPI.Core.Repositories
{
    public interface ISessionRepository :  IRepository<Session>
    {
        void CreateSession(User user);
    }
}
