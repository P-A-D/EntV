using EntV.Data;
using EntV.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Student entity)
        {
            _db.Students.Add(entity);
            return Save();
        }

        public bool Delete(Student entity)
        {
            _db.Students.Remove(entity);
            return Save();
        }

        public bool Exists(int id)
        {
            return _db.Students.Any(q => q.StudentId == id);
        }

        public ICollection<Student> FindAll()
        {
            return _db.Students.ToList();
        }

        public Student FindById(int id)
        {
            return _db.Students.Find(id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Student entity)
        {
            _db.Students.Update(entity);
            return Save();
        }
    }
}
