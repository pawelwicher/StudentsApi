using System.Collections.Generic;
using Newtonsoft.Json;
using Students.Data;
using Students.Model.Domain;
using Students.Repositories.Interfaces;

namespace Students.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> Get()
        {
            return JsonConvert.DeserializeObject<IEnumerable<Student>>(FakeApi.GetStudentsJson());
        }
    }
}