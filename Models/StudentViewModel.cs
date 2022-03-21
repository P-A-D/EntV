using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Models
{
    public class StudentViewModel
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Student ID")]
        public string StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        public string BirthDate { get; set; }
        [Required]
        [Display(Name = "Melli Code")]
        public string MelliCode { get; set; }
        [Required]
        [Display(Name = "Entrance Date")]
        public string EntranceDate { get; set; }
        public EnrollmentTypeViewModel EnrollmentType { get; set; }
        [Display(Name = "Enrollment Type ID")]
        public int EnrollmentTypeId { get; set; }
        [Display(Name = "Enrollment Type")]
        public string EnrollmentTypeName { get; set; }
        public DepartmentViewModel Department { get; set; }
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        // The two lines below allow for getting the list of enrollment types and departments and provide them to the user to select from
        public IEnumerable<SelectListItem> EnrollmentTypes { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
