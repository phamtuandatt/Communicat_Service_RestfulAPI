using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_Data;
using OA_Service;

namespace OA_Web_Student.Controllers
{
    [Route("api/[controller]")]
    public class StudentAPIController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentAPIController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Student> Get()
        {
            return studentService.GetStudents();
        }

        [HttpGet("list")]
        [Route("students")]
        public IActionResult students()
        {
            return Ok(studentService.GetStudents());
        }
    }
}
