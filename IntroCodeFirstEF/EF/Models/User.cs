using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IntroCodeFirstEF.EF.Models
{
    public class User
    {
        [Key] // primary key
        [Required] // not null
        public string Username { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}