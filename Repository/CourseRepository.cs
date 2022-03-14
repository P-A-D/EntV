using EntV.Data;
using EntV.Repository.Interfaces;
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

        public ICollection<Course> FindAll()
        {
            return _db.Courses.ToList();
        }

        public Course FindById(int id)
        {
            return _db.Courses.Find(id);
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
