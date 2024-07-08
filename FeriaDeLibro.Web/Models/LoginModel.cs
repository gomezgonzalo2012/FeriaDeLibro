using System.ComponentModel.DataAnnotations;

namespace FeriaDeLibro.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Nombre de usuario obligatorio.")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Contraseña obligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
