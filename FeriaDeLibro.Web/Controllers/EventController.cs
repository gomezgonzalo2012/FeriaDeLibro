using FeriaDeLibro.Entities.Models;
using FeriaDeLibro.Service.Interfaces;
using FeriaDeLibro.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace FeriaDeLibro.Web.Controllers
{
    [ValidateSession]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ICourseService _courseService;
        public EventController (IEventService eventService, ICourseService courseService)
        {
            _eventService = eventService;
            _courseService = courseService;
        }
        public IActionResult Start()
        {
            if (TempData["SuccessMessage"] != null) // ca
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            var coursesDB = _courseService.GetAllCourses();
            var courseList = new SelectList(coursesDB, "CourseId", "CourseName");
            ViewBag.Courses = courseList;
            return View("/Views/Admin/Index.cshtml");
        }
        // POST: Event/Create
        [HttpPost]
        public IActionResult Create(/*[Bind("Name, EventDate, EventTime,EventDescription, CourseId")] Event*/ SingleEventModel eventModel)
        {
            //if (ModelState.IsValid)
            //{
                var fechaActual = DateOnly.FromDateTime(DateTime.Now);

                if (eventModel.EventDate > fechaActual.AddDays(10)) // 1 dia para que no impida la dif de segundos
                {
                    ViewBag.Alert = "Lo sentimos, no se pueden cargar fechas posteriores al evento";

                }
                else if (eventModel.EventDate < fechaActual.AddDays(-1))
                {
                    ViewBag.Alert = "Lo sentimos, No se pueden cargar fechas pasadas.";
                }
                else
                {
                var eventDB = new Event()
                {
                    Name = eventModel.EventName,
                    EventDate = eventModel.EventDate,
                    EventTime = eventModel.StartTime,
                    EventDescription = eventModel.Description,
                    Image = " ",
                    CourseId = eventModel.Curso.CourseId
                };
                    var eventResult = _eventService.AddEvent(eventDB);
                    if (eventResult.IsSucces)
                    {
                        TempData["SuccessMessage"] = "Evento creado con éxito.";
                        return RedirectToAction("Start"); // retornar mensaje de exito
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, eventResult.ErrorMessage);
                        //return RedirectToAction("Start", ViewBag.Alert = eventResult.ErrorMessage);
                    }

                //}
               
            }
            var coursesDB = _courseService.GetAllCourses();
            var courseList = new SelectList(coursesDB, "CourseId", "CourseName");
            ViewBag.Courses = courseList;
            return View("/Views/Admin/Index.cshtml", eventModel); // verificar
        }

        

    }
}
