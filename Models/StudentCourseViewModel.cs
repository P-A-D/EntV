using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Models
{
    public class StudentCourseViewModel
    {
        [Key]
        [Display(Name = "Acquisition ID")]
        public int AcquisitionId { get; set; }
        [Required]
        public string Semester { get; set; }
        public StudentViewModel Student { get; set; }
        [Required]
        [Display(Name = "Student ID")]
        public int StudentId { get; set; }
        public CourseViewModel Course { get; set; }
        [Display(Name = "Course ID")]
        [Required]
        public int CourseId { get; set; }
        // The two lines below allow for getting the list of enrollment types and departments and provide them to the user to select from
        public IEnumerable<SelectListItem> Students { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }
    }
}
