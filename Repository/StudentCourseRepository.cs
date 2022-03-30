using EntV.Data;
using EntV.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Repository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentCourseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(StudentCourse entity)
        {
            _db.StudentCourses.Add(entity);
            return Save();
        }

        public bool Delete(StudentCourse entity)
        {
            _db.StudentCourses.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return _db.StudentCourses.Any(q => q.AcquisitionId == id);
        }

        public ICollection<StudentCourse> FindAll()
        {
            return _db.StudentCourses.Include(q => q.Student).Include(q => q.Course).ToList();
        }

        public StudentCourse FindById(int id)
        {
            return _db.StudentCourses.Include(q => q.Student).Include(q => q.Course).FirstOrDefault(q => q.AcquisitionId == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(StudentCourse entity)
        {
            _db.StudentCourses.Update(entity);
            return Save();
        }
    }
}
