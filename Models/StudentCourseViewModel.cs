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
        // This view model is not used, since the StudentCourse table is not yet added to the database (Through the ApplicatinDbContext)
        public int AcquisitionId { get; set; }
        [Required]
        public string Semester { get; set; }
        public StudentViewModel Student { get; set; }
        public int StudentId { get; set; }
        public CourseViewModel Course { get; set; }
        public int CourseId { get; set; }
        // The two lines below allow for getting the list of enrollment types and departments and provide them to the user to select from
        public IEnumerable<SelectListItem> Students { get; set; }
        public IEnumerable<SelectListItem> Courses { get; set; }
    }
}
