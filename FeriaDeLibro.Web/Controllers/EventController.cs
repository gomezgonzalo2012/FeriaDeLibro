using FeriaDeLibro.Entities.Models;
using FeriaDeLibro.Service.Interfaces;
using FeriaDeLibro.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;

namespace FeriaDeLibro.Web.Controllers
{
    [ValidateSession]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ICourseService _courseService;
        private readonly IImageUploadService _imageUploadService;
        public EventController (IEventService eventService, ICourseService courseService, IImageUploadService imageService)
        {
            _eventService = eventService;
            _courseService = courseService;
            _imageUploadService = imageService;
        }
        public async Task<IActionResult> Start(EventModel events)
        {
            events.Events= await _eventService.GetAllEvents();
            
            
            return View("/Views/Admin/Index.cshtml", events);
        }public async Task<IActionResult> Initializer() // carga los cursos para las paginas edit y create
        {
            if (TempData["SuccessMessage"] != null) 
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }
            
            var coursesDB = await _courseService.GetAllCourses();
            var courseList = new SelectList(coursesDB, "CourseId", "CourseName");
            ViewBag.Courses = courseList;
            return View("/Views/Admin/Create.cshtml");
        }
        // POST: Event/Create
        [HttpPost]
        public async Task<IActionResult> Create(/*[Bind("Name, EventDate, EventTime,EventDescription, CourseId")] Event*/ SingleEventModel eventModel)
        {
            

            if (ModelState.IsValid)
            {
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
                        CourseId = eventModel.Curso.CourseId
                    };
                if (eventModel.Image == null)
                {
                    eventDB.Image = "/images/tecnicatura_destacada.jpeg";
                }
                else
                {
                    eventDB.Image = await _imageUploadService.SaveImage(eventModel.Image); // llama al servicio para guardar imagen
                }

                var eventResult = await _eventService.AddEvent(eventDB);
                    if (eventResult.IsSucces)
                    {
                        TempData["SuccessMessage"] = "Evento creado con éxito.";
                        return RedirectToAction("Initializer"); // retornar mensaje de exito
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, eventResult.ErrorMessage);
                        //return RedirectToAction("Start", ViewBag.Alert = eventResult.ErrorMessage);
                    }

                }

            }
            else
            {
                var coursesDB = await _courseService.GetAllCourses();
                var courseList = new SelectList(coursesDB, "CourseId", "CourseName");
                ViewBag.Courses = courseList;
                TempData[""] = "No se pudo crear el evento, asegurece de completar todos los campos";

                return View("/Views/Admin/Create.cshtml", eventModel); // retorna con los errores

            }
            return View("/Views/Admin/Create.cshtml", eventModel);


        }

        [HttpPost]
        public async Task<IActionResult> Delete(int eventId)
        {
            var eventToDelete = await _eventService.GetEventById(eventId);
            if (eventToDelete == null)
            {
                return NotFound();
            }
            await _eventService.RemoveEvent( eventToDelete);
            return RedirectToAction("Start");
        }

        
        public async Task<IActionResult> EditInit(int eventId)
        {
            // Lógica para editar el evento con el ID especificado
            var eventToEdit = await _eventService.GetEventById(eventId);
            var cursoModel = new CourseViewModel
            {
                CourseId = eventToEdit.CourseId,
                CourseName = eventToEdit.Course.CourseName
            };
            var eventModel = new SingleEventModel
            {
                Id= eventToEdit.EventId,
                EventName = eventToEdit.Name,
                EventDate = eventToEdit.EventDate,
                StartTime = eventToEdit.EventTime,
                Description = eventToEdit.EventDescription,
                //Course = eventToEdit.Course.CourseName,
                Curso = cursoModel
            };
            if (eventToEdit == null)
            {
                return NotFound();
            }
            var coursesDB = await _courseService.GetAllCourses();
            var courseList = new SelectList(coursesDB, "CourseId", "CourseName");
            ViewBag.Courses = courseList;
            return View("/Views/Admin/Edit.cshtml",eventModel);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(SingleEventModel eventModel)
        {

            if (ModelState.IsValid)
            {
                var fechaActual = DateOnly.FromDateTime(DateTime.Now);

                if (eventModel.EventDate > fechaActual.AddDays(10)) // 1 dia para que no impida la dif de segundos
                {
                    ViewBag.Alert = "Lo sentimos, no se pueden cargar fechas posteriores al evento";

                }
                else if (eventModel.EventDate < fechaActual.AddDays(-1))
                {
                    ViewBag.Alert = "Lo sentimos, No se pueden cargar fechas pasadas.";
                }
                else/* if (eventModel.Image.Length > 0)*/
                {
                    var eventToEdit = new Event()
                    {

                        EventId = eventModel.Id,
                        Name = eventModel.EventName,
                        EventDate = eventModel.EventDate,
                        EventTime = eventModel.StartTime,
                        EventDescription = eventModel.Description,
                        CourseId = eventModel.Curso.CourseId
                    };
                    if (eventModel.Image == null)
                    {
                        eventToEdit.Image = "/images/tecnicatura_destacada.jpeg";
                    }
                    else
                    {
                        eventToEdit.Image = await _imageUploadService.SaveImage(eventModel.Image); // llama al servicio para guardar imagen

                    }

                    await _eventService.UpdateEvent(eventToEdit);

                    TempData["SuccessMessage"] = "Evento creado con éxito.";

                    return RedirectToAction("Start");

                }
            }
               
            var coursesDB = await _courseService.GetAllCourses();
            var courseList = new SelectList(coursesDB, "CourseId", "CourseName");
            ViewBag.Courses = courseList;
            return View("/Views/Admin/Edit.cshtml", eventModel); // retorna con los errores
            
        }

        
    }
}
