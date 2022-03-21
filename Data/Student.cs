using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Data
{
    public class Student : IdentityUser
    {
        [Required]
        [Index(nameof(StudentId), IsUnique = true)]
        public string StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BirthDate { get; set; }
        [Required]
        public string MelliCode { get; set; }
        [Required]
        public string EntranceDate { get; set; }
        [ForeignKey("EnrollmentTypeId")]
        public EnrollmentType EnrollmentType { get; set; }
        public int EnrollmentTypeId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
