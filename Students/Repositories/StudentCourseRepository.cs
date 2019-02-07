using System.Collections.Generic;
using Newtonsoft.Json;
using Students.Data;
using Students.Model;
using Students.Repositories.Interfaces;

namespace Students.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        public IEnumerable<StudentCourse> Get()
        {
            return JsonConvert.DeserializeObject<IEnumerable<StudentCourse>>(FakeApi.GetStudentCoursesJson());
        }
    }
}