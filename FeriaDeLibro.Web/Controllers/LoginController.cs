using FeriaDeLibro.Service.Interfaces;
using FeriaDeLibro.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeriaDeLibro.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IUserService _userService;

        public LoginController(ILoginService loginService, IUserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }
        public IActionResult Start()
        {
            return View("/Views/Login/Login.cshtml");
        }
        public IActionResult CerrarSesion()
        {
            // Eliminar la sesión del usuario
            HttpContext.Session.Remove("UsuarioModel");

            // Opción adicional para limpiar todas las sesiones
            // HttpContext.Session.Clear();

            // Redirigir al login
            return RedirectToAction("Start", "Login");
        }
        [HttpPost]
        public async Task<IActionResult> Validate(LoginModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _loginService.Verify(model.UserName, model.Password);
                var userDb = await _userService.GetUserByName(model.UserName);
                if(result.IsSucces)
                {
                    HttpContext.Session.SetObject("UsuarioModel", userDb);

                    return RedirectToAction("Admin","Home"); // pasar con la sesion de usuario
                }else if(result.Value == 1)
                {
                    ModelState.AddModelError(string.Empty, result.ErrorMessage);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.ErrorMessage);
                }
                
            }
            return View("Login",model);
        }
    }
}
