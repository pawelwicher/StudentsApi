using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Students.Model;

namespace Students.DataAccess
{
    public static class FakeDb
    {
        public static IEnumerable<Student> GetAllStudents()
        {
            return GetDataFromJson<IEnumerable<Student>>("Students.DataAccess.JsonData.Students.json");
        }

        public static IEnumerable<Course> GetAllCourses()
        {
            return GetDataFromJson<IEnumerable<Course>>("Students.DataAccess.JsonData.Courses.json");
        }

        public static IEnumerable<StudentCourse> GetAllStudentCourses()
        {
            return GetDataFromJson<IEnumerable<StudentCourse>>("Students.DataAccess.JsonData.StudentCourses.json");
        }

        private static T GetDataFromJson<T>(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }
    }
}