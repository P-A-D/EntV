using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Models
{
    public class CourseViewModel
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int UnitCount { get; set; }
        public DepartmentViewModel Department { get; set; }
        public int DepartmentId { get; set; }
        // The two lines below allow for getting the list of enrollment types and departments and provide them to the user to select from
        public IEnumerable<SelectListItem> Departments { get; set; }
    }
}
