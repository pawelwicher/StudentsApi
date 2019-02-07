using System.Collections.Generic;

namespace Students.Model.Dto
{
    public class StudentDetailDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int IndexNumber { get; set; }

        public IEnumerable<StudentCoursesListDto> Courses { get; set; }
    }
}