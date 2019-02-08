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
            var students = this.studentRepository.GetAll();
            var studentCourses = this.studentCourseRepository.GetAll();

            return students
                .OrderBy(x => x.LastName)
                .Select(student => new StudentListDto
                {
                    Id = student.Id,
                    LastNameAndFirstName = $"{student.LastName} {student.FirstName}",
                    IndexNumber = student.Index,
                    NumberOfCoursesPassed = studentCourses.Where(course => course.StudentId == student.Id && course.Grade >= 3.0M).Count(),
                    NumberOfCoursesFailed = studentCourses.Where(course => course.StudentId == student.Id && course.Grade < 3.0M).Count()
                });
        }

        public StudentDto GetStudent(int id)
        {
            var student = this.studentRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();

            if (student != null)
            {
                var courses = this.courseRepository.GetAll().ToDictionary(x => x.Id);
                var studentCourses = this.studentCourseRepository.GetAll().Where(x => x.StudentId == student.Id);

                return new StudentDto
                {
                    LastNameAndFirstName = $"{student.LastName} {student.FirstName}",
                    IndexNumber = student.Index,
                    Courses = studentCourses.Select(x => new StudentCoursesListDto
                    {
                        Grade = x.Grade,
                        Name = courses[x.CourseId].Name
                    })
                };
            }

            return null;
        }

    }
}