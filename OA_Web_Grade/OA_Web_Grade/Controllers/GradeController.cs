using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OA_Data;
using OA_Serivce;
using OA_Web_Grade.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace OA_Web_Grade.Controllers
{
    public class GradeController : Controller
    {
        // Define DbContext
        private readonly IGradeService gradeService;
        private IHttpClientFactory factory;

        public GradeController(IGradeService gradeService, IHttpClientFactory factory)  
        {
            this.gradeService = gradeService;
            this.factory = factory;
        }

        public async Task<IActionResult> StudentAPI_Detail()
        {
            using (var client = new HttpClient())
            {
                // Get link of API
                client.BaseAddress = new Uri("https://localhost:7007/");
                
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // Access API
                HttpResponseMessage response = await client.GetAsync("api/StudentAPI/Get");

                if (response.IsSuccessStatusCode)
                {
                    var details = response.Content.ReadAsAsync<IEnumerable<Student>>().Result;
                    
                    //return Ok(details);
                    return View(details);
                }
                else
                {
                    return NotFound("No found");
                }
            }
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
