namespace Students.Model.Dto
{
    public class StudentListDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int IndexNumber { get; set; }

        public int CoursesPassedCount { get; set; }

        public int CoursesFailedCount { get; set; }
    }
}