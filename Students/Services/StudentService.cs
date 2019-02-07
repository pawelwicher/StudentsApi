using System.Collections.Generic;
using System.Linq;
using Students.Model.Dto;
using Students.Repositories.Interfaces;
using Students.Services.Interfaces;

namespace Students.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IStudentCourseRepository studentCourseRepository;

        public StudentService(
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IStudentCourseRepository studentCourseRepository)
        {
            (this.studentRepository, this.courseRepository, this.studentCourseRepository) = (studentRepository, courseRepository, studentCourseRepository);
        }

        public IEnumerable<StudentListDto> GetStudents()
        {
            var students = this.studentRepository.Get();
            var courses = this.courseRepository.Get();
            var studentCourses = this.studentCourseRepository.Get();

            return students.Select(student => new StudentListDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                IndexNumber = student.IndexNumber,
                CoursesPassedCount = studentCourses.Where(course => course.StudentId == student.Id && course.Grade >= 3.0M).Count(),
                CoursesFailedCount = studentCourses.Where(course => course.StudentId == student.Id && course.Grade < 3.0M).Count()
            }).OrderBy(x => x.LastName);
        }

        public StudentDetailDto GetStudent(int id)
        {
            var student = this.studentRepository.Get().Where(x => x.Id == id).FirstOrDefault();

            if (student != null)
            {
                var courses = this.courseRepository.Get();
                var studentCourses = this.studentCourseRepository.Get().Where(x => x.StudentId == student.Id);

                return new StudentDetailDto
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    IndexNumber = student.IndexNumber,
                    Courses = studentCourses.Select(x => new StudentCoursesListDto
                    {
                        Grade = x.Grade,
                        Name = courses.Where(course => course.Id == x.CourseId).FirstOrDefault().Name
                    })
                };
            }

            return null;
        }

    }
}