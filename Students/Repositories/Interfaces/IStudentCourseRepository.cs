using Students.Model.Domain;
using System.Collections.Generic;

namespace Students.Repositories.Interfaces
{
    public interface IStudentCourseRepository
    {
        IEnumerable<StudentCourse> Get();
    }
}