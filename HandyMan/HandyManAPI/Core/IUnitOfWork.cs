using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HandyManAPI.Core.Repositories;

namespace HandyManAPI.Core
{
    interface IUnitOfWork : IDisposable
    {
        IJobRepository Jobs { get; }
        IUserRepository Users { get; }

        ILoginRepository Login { get; }

        ISessionRepository Session { get; }
    }
}
