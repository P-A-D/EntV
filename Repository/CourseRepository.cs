using EntV.Data;
using EntV.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _db;
        public CourseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Course entity)
        {
            _db.Courses.Add(entity);
            return Save();
        }

        public bool Delete(Course entity)
        {
            _db.Courses.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            //return _db.Courses.Any(); // This line of code checks to see if the table is empty or not
            // The line of code below does the following (it is a lambda expression): Consider an object of Courses table named q.
            // Return this object/list of objects whenever they have a course id identical to the given id.
            return _db.Courses.Any(q => q.CourseId == id);
        }

        public ICollection<Course> FindAll()
        {
            var courses = _db.Courses.Include(q => q.Department).ToList();
            return _db.Courses.ToList();
        }

        public Course FindById(int id)
        {
            return _db.Courses.Include(q => q.Department).FirstOrDefault(q => q.CourseId== id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Course entity)
        {
            _db.Courses.Update(entity);
            return Save();
        }
    }
}
