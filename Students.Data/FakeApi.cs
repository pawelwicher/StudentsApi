using System.IO;
using System.Reflection;

namespace Students.Data
{
    public static class FakeApi
    {
        public static string GetStudentsJson()
        {
            return GetJson("Students.Data.Json.Students.json");
        }

        public static string GetCoursesJson()
        {
            return GetJson("Students.Data.Json.Courses.json");
        }

        public static string GetStudentCoursesJson()
        {
            return GetJson("Students.Data.Json.StudentCourses.json");
        }

        private static string GetJson(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}