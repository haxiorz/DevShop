using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DevShop.Data.Models
{
    public class ExtendedIdentityUser : IdentityUser
    {
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        [StringLength(1)]
        public char Gender { get; set; }
        public Country Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
