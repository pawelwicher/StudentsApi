namespace Students.Model.Domain
{
    public class StudentCourse
    {
        public int Id { get; set; }

        public decimal Grade { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }
    }
}