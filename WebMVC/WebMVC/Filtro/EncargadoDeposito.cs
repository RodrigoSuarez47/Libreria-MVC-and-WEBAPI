using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Filtro
{
    public class EncargadoDeposito: Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string rol = context.HttpContext.Session.GetString("RolUsuario");
            if (string.IsNullOrEmpty(rol))
            {
                context.Result = new RedirectResult("/Usuarios/Login");
            }
            else if (rol != "EncargadoDeposito")
            {
                context.Result = new RedirectResult("/Usuarios/Login");
            }
        }
    }
}
