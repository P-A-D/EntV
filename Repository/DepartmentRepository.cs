using EntV.Data;
using EntV.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(Department entity)
        {
            _db.Departments.Add(entity);
            return Save();
        }

        public bool Delete(Department entity)
        {
            _db.Departments.Remove(entity);
            return Save();
        }

        public ICollection<Department> FindAll()
        {
            return _db.Departments.ToList();
        }

        public Department FindById(int id)
        {
            return _db.Departments.Find(id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public bool Update(Department entity)
        {
            _db.Departments.Update(entity);
            return Save();
        }
    }
}
