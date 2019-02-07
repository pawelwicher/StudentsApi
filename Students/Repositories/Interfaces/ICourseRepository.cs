using Students.Model.Domain;
using System.Collections.Generic;

namespace Students.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> Get();
    }
}