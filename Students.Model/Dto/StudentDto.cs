using System.Collections.Generic;

namespace Students.Model.Dto
{
    public class StudentDto
    {
        public string LastNameAndFirstName { get; set; }

        public int IndexNumber { get; set; }

        public IEnumerable<StudentCoursesListDto> Courses { get; set; }
    }
}