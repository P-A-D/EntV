using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using EntV.Models;

namespace EntV.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EnrollmentType> EnrollmentTypes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<EntV.Models.MemberViewModel> MemberViewModel { get; set; }
        //public DbSet<EntV.Models.EnrollmentTypeViewModel> EnrollmentTypeViewModel { get; set; }
        //public DbSet<EntV.Models.DepartmentViewModel> DepartmentViewModel { get; set; }
    }
}
