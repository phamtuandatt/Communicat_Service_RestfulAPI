using Microsoft.AspNetCore.Mvc;

namespace APIGateway_Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
