using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace HandyManAPI.Models
{
    public class Login
    {
        public User User { get; set; }
        public Guid UserId { get; set; }

        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
       public byte[] PasswordSalt { get; set; }
        public int Id { get; set; }



    }
}