using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HandyManAPI.Models
{
    public class User
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        
        public List<Job> Jobs { get; set; }
    }
}