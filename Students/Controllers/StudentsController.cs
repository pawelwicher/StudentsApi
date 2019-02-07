using Microsoft.AspNetCore.Mvc;
using Students.Model.Dto;
using Students.Services.Interfaces;
using System.Collections.Generic;

namespace Students.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentListDto>> Get()
        {
            return Ok(this.studentService.GetStudents());
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDto> Get(int id)
        {
            var student = this.studentService.GetStudent(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(this.studentService.GetStudent(id));
        }
    }
}