using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Data
{
    public class EnrollmentType
    {
        [Key]
        public int EnrollmentTypeId { get; set; }
        [Required]
        public string EnrollmentTypeName { get; set; }
    }
}
