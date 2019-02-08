namespace Students.Model.Dto
{
    public class StudentListDto
    {
        public int Id { get; set; }

        public string LastNameAndFirstName { get; set; }

        public int IndexNumber { get; set; }

        public int NumberOfCoursesPassed { get; set; }

        public int NumberOfCoursesFailed { get; set; }
    }
}