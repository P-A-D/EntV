using AutoMapper;
using EntV.Data;
using EntV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Mappings
{
    public class AutoMapClassToVM : Profile
    {
        public AutoMapClassToVM()
        {
            CreateMap<Course, CourseViewModel>().ReverseMap();
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<EnrollmentType, EnrollmentTypeViewModel>().ReverseMap();
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Member, MemberViewModel>().ReverseMap();
            //CreateMap<StudentCourse, StudentCourseViewModel>().ReverseMap();
        }
    }
}
