using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Data
{
    public class StudentCourse
    {
        // This class has not been added to the database. Check the ApplicationDbContext.cs for the addition. Adding the migration causes a type-mismatch in the foreign keys
        // The issue arises from the fact that this way of definition of table references StudentId (data type: int) to the Id of the IdentityUsers table (data type: string) instead of 
        // referencing it to the StudentId column defined in the Student.cs. Find out how to reference the proper column and then run the proper migration.
        [Key]
        public int AcquisitionId { get; set; }
        [Required]
        [StringLength(2)]
        public string Semester { get; set; }
        [ForeignKey("Id")]
        public Student Student { get; set; }
        [Required]
        public int StudentId { get; set; }
        [ForeignKey("CourseId")]
        public Course Course { get; set; }
        [Required]
        public int CourseId { get; set; }
    }
}
