using Microsoft.AspNetCore.Mvc;
using OA_Data;
using OA_Service;

namespace OA_Web_Student.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var lst_student = studentService.GetStudents();
            return View(lst_student);
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            if (student is null)
            {
                return NotFound("Can't create student");
            }
            try
            {
                Student st = new Student
                {
                    Id = student.Id,
                    Name = student.Name,
                    DayOfBirth = student.DayOfBirth,
                    Phone = student.Phone,
                    Email = student.Email,
                    Address = student.Address,
                };
                studentService.InsertStudent(st);

                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound("Can't create student");
            }
        }

        [HttpGet]
        public IActionResult UpdateStudent(int Id)
        {
            var student = studentService.GetStudent(Id);

            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student)
        {
            if (student is null)
            {
                return NotFound("Can't update student");
            }
            try
            {
                Student st = new Student
                {
                    Id = student.Id,
                    Name = student.Name,
                    DayOfBirth = student.DayOfBirth,
                    Phone = student.Phone,
                    Email = student.Email,
                    Address = student.Address,
                };

                studentService.UpdateStudent(st);

                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound("Can't update student");
            }
        }

        public IActionResult DeleteStudent(int Id)
        {
            try
            {
                studentService.DeleteStudent(Id);
                return RedirectToAction("Index");
            }
            catch 
            {
                return NotFound("Can't delete Student");
            }
            
            
        }
    }
}
