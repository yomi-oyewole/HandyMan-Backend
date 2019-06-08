using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandyManAPI.Models
{
    public class Session
    {
        public string Token { get; set; }
        public User UserId { get; set; }
    }
}