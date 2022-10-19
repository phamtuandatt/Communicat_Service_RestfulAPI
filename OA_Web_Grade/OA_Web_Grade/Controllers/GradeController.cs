using Microsoft.AspNetCore.Mvc;
using OA_Data;
using OA_Serivce;

namespace OA_Web_Grade.Controllers
{
    public class GradeController : Controller
    {
        // Define DbContext
        private readonly IGradeService gradeService;

        public GradeController(IGradeService gradeService)
        {
            this.gradeService = gradeService;
        }

        public IActionResult Index()
        {
            var lst_grade = gradeService.GetGrades();
            return View(lst_grade);
        }

        [HttpGet]
        public IActionResult AddGrade()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGrade(Grade grade)
        {
            if (grade is null)
            {
                return NotFound("Can't create Grade");
            }
            try
            {
                Grade gd = new Grade
                {
                    MaLop = grade.MaLop,
                    TenLop = grade.TenLop,
                    SiSo = grade.SiSo,
                };
                gradeService.Insert(gd);

                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound("Can't create Grade");
            }
        }

        [HttpGet]
        public IActionResult UpdateGrade(int Id)
        {
            var gr = gradeService.GetGrade(Id);
            return View(gr);
        }

        [HttpPost]
        public IActionResult UpdateGrade(Grade grade)
        {

            if (grade is null)
            {
                return NotFound("Can't update Grade");
            }
            try
            {
                Grade gd = new Grade
                {
                    MaLop = grade.MaLop,
                    TenLop = grade.TenLop,
                    SiSo = grade.SiSo
                };

                gradeService.Update(gd);

                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound("Can't update Grade");
            }
        }

        public IActionResult DeleteGrade(int Id)
        {
            try
            {
                gradeService.Delete(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound("Can't delete Grade");
            }
        }
    }
}
