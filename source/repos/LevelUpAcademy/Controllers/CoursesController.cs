using Microsoft.AspNetCore.Mvc;

namespace LevelUpAcademy.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
