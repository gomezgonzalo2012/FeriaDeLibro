using FeriaDeLibro.Service.Interfaces;
using FeriaDeLibro.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FeriaDeLibro.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventService _eventService;
        //private readonly ICourseService _courseService;

        public HomeController(ILogger<HomeController> logger, IEventService eventService/*, ICourseService courseService*/)
        {
            _logger = logger;
            _eventService = eventService;
            //_courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var futureEvents = await _eventService.GetAllFutureEvents();
            var eventsModel = new EventModel
            {
                Events = futureEvents
            };
            return View(eventsModel);
        }
        // Action course1 
        //public IActionResult Course1(int id)
        //{
        //    var course1 = _courseService.GetCourseById(id);
        //    var courseModel = new CourseModel
        //    {
        //        Nombre = course1.Name,
        //        Duracion = course1.CourseLength,
        //    };
        //    return View(courseModel);
        //}
        public IActionResult Programming()
        {
            return View("/Views/Course/Programming.cshtml");
        }
        public IActionResult PcManager()
        {
            return View("/Views/Course/PcManager.cshtml");
        }
        public IActionResult PcRepair()
        {
            return View("/Views/Course/PcRepair.cshtml");
        }
        public IActionResult Mecatronic()
        {
            return View("/Views/Course/Mecatronic.cshtml");
        }
        [ValidateSession]
        public IActionResult Admin()
        {
            return RedirectToAction("Start","Event");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
