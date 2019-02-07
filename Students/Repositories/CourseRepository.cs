using System.Collections.Generic;
using Newtonsoft.Json;
using Students.Data;
using Students.Model;
using Students.Repositories.Interfaces;

namespace Students.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        public IEnumerable<Course> Get()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Course>>(FakeApi.GetCoursesJson());
        }
    }
}