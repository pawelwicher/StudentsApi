using Students.Model.Dto;
using System.Collections.Generic;

namespace Students.Services.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentListDto> GetStudents();

        StudentDetailDto GetStudent(int id);
    }
}