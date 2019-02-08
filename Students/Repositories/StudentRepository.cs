using System.Collections.Generic;
using Students.DataAccess;
using Students.Model;
using Students.Repositories.Interfaces;

namespace Students.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetAll()
        {
            return FakeDb.GetAllStudents();
        }
    }
}