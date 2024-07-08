using Microsoft.AspNetCore.Mvc;

namespace FeriaDeLibro.Web.Controllers
{
    [ValidateSession]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
