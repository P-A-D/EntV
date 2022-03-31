using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(7)]
        public string StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(10)]
        public string MelliCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(2)]
        public string EntranceDate { get; set; }
        [ForeignKey("EnrollmentTypeId")]
        public EnrollmentType EnrollmentType { get; set; }
        public int EnrollmentTypeId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
