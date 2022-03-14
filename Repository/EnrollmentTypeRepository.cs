using EntV.Data;
using EntV.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Repository
{
    public class EnrollmentTypeRepository : IEnrollmentTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public EnrollmentTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(EnrollmentType entity)
        {
            _db.EnrollmentTypes.Add(entity);
            return Save();
        }

        public bool Delete(EnrollmentType entity)
        {
            _db.EnrollmentTypes.Remove(entity);
            return Save();
        }

        public ICollection<EnrollmentType> FindAll()
        {
            return _db.EnrollmentTypes.ToList();
        }

        public EnrollmentType FindById(int id)
        {
            return _db.EnrollmentTypes.Find(id);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
            // The _db.SaveChanges() returns the number of changes made to the database.
        }

        public bool Update(EnrollmentType entity)
        {
            _db.EnrollmentTypes.Update(entity);
            return Save();
        }
    }
}
