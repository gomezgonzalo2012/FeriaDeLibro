using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FeriaDeLibro.Web
{
    public class ValidateSessionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("UsuarioModel") == null)
            {
                context.Result = new RedirectToActionResult("Start", "Login", null);
            }

            base.OnActionExecuting(context);
        }
    }
}
