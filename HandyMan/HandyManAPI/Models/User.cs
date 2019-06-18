using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HandyManAPI.Models
{
    public class User
    {

        public User()
        {
            Jobs = new HashSet<Job>();
        }


        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        //public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }

        public string Token { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        
        public ICollection<Job> Jobs { get; set; }
    }
}