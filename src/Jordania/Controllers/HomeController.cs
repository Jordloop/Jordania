using Microsoft.AspNetCore.Mvc;

namespace Jordania.Controllers
{
    public class HomeController : Controller
    {
//Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
