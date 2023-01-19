using Microsoft.AspNetCore.Mvc;

namespace Aula01_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
