using Students.Model;
using System.Collections.Generic;

namespace Students.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
    }
}