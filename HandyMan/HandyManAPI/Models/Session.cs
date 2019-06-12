using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace HandyManAPI.Models
{
    public class Session
    {
        public string Token { get; set; }
        public User User{ get; set; }
        public Guid UserId { get; set; }
        public int Id { get; set; }


    }
}