using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Models
{
    public class CourseViewModel
    {
        [Key]
        [Display(Name = "Course ID")]
        public int CourseId { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Required]
        [Display(Name = "Unit Count")]
        public int UnitCount { get; set; }
        public DepartmentViewModel Department { get; set; }
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }
        [Display(Name = " Deparment Name")]
        public string DepartmentName { get; set; }
        // The two lines below allow for getting the list of enrollment types and departments and provide them to the user to select from
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
