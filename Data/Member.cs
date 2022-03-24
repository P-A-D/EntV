using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Data
{
    // This class is meant for the authenticated users that work at the educational department with enough privileges to change student info.
    public class Member : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MelliCode { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }

    }
}
