using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Models
{
    public class AddOrEditStudentViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Student ID")]
        public string StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Please enter a valid Melli code.")]
        [Display(Name = "Melli Code")]
        public string MelliCode { get; set; }
        [Required]
        [Display(Name = "Entrance Date")]
        [StringLength(2, ErrorMessage = "The entrance date has to have 2 digits.")]
        public string EntranceDate { get; set; }
        [Required(ErrorMessage = "Please select an enrollment type")]
        public int EnrollmentTypeId { get; set; }
        [Required(ErrorMessage ="Please select a department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Department Name")]
        public IEnumerable<SelectListItem> Departments { get; set; }
        [Display(Name = "Enrollment Type")]
        public IEnumerable<SelectListItem> EnrollmentTypes { get; set; }
    }
}
