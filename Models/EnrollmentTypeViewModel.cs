using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Models
{
    public class EnrollmentTypeViewModel
    {
        [Key]
        [Display(Name = "Enrollment Type Code")]
        public int EnrollmentTypeId { get; set; }
        [Required]
        [Display(Name = "Enrollment Type Name")]
        public string EnrollmentTypeName { get; set; }
    }
}
