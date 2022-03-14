using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Models
{
    public class DepartmentViewModel
    {
        [Required]
        public string DepartmentName { get; set; }
    }
}
