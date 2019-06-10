using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyManAPI.Models;

namespace HandyManAPI.Core.Repositories
{
    public interface ILoginRepository : IRepository<Login>
    {
        User Authenticate(string email, string password);
    }
}
