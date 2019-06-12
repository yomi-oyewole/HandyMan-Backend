using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HandyManAPI.Models;

namespace HandyManAPI.DataContext
{
    public class HandyManContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Session> Sessions { get; set; }
       public DbSet<Login> Logins { get; set; }

        public HandyManContext() : base("name=HandyManConnection")
        {
               
        }    


    }
}