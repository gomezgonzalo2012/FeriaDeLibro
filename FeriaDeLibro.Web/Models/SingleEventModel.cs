using FeriaDeLibro.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace FeriaDeLibro.Web.Models
{
    public class SingleEventModel
    {
        public int Id { get; set; } = 0;
        // agregar validaciones de fecha hora (min y max) 
        [Required (ErrorMessage = "El nombre del evento es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del evento no puede tener más de 100 caracteres.")]
        public string EventName { get; set; }
        [Required(ErrorMessage = "La hora del evento es obligatoria.")]
        [DataType(DataType.Time, ErrorMessage ="La hora no es válida.")]
        public TimeOnly StartTime { get; set; }
        [Required (ErrorMessage = "La fecha del evento es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage= "La fecha no es válida.")]
        public DateOnly EventDate { get; set; }
        //[Required(ErrorMessage ="El curso es obligatorio.")] 
        //public string Course { get; set; }
        ////public Course Course { get; set; }
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Imagen requerida.")]
        public IFormFile Image { get; set; } /* Dato de tipo Imagen*/
        [Required(ErrorMessage ="Agrega descripción al evento.")]
        [StringLength(256, ErrorMessage = "El nombre del evento no puede tener más de 256 caracteres.")]
       
        public string Description { get; set; }
        [Required(ErrorMessage = "Selecciona un curso.")]
        public CourseViewModel Curso { get; set; }
    }

}
