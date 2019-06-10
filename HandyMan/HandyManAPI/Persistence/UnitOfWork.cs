using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HandyManAPI.Core;
using HandyManAPI.Core.Repositories;
using HandyManAPI.DataContext;
using HandyManAPI.Models;
using HandyManAPI.Persistence.Repositories;

namespace HandyManAPI.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HandyManContext _context;
        public IJobRepository Jobs { get; }
        public IUserRepository Users { get; }
        public ILoginRepository Login { get; }

        public UnitOfWork(HandyManContext context)
        {
            _context = context;
            Jobs = new JobRepository(context);
            Users = new UserRepository(context);
            Login = new LoginRepository(context);
           
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}