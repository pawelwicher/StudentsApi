using System.Collections.Generic;
using Students.DataAccess;
using Students.Model;
using Students.Repositories.Interfaces;

namespace Students.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        public IEnumerable<StudentCourse> GetAll()
        {
            return FakeDb.GetAllStudentCourses();
        }
    }
}