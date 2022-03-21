using EntV.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntV.Repository.Interfaces
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        int Count(string yearNumber, int departmentId);
    }
}
