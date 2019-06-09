using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HandyManAPI.Models
{
    public class Job
    {
        public User User { get; set; }
        public string UserId { get; set; }

        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Summary { get; set; }
    }
}