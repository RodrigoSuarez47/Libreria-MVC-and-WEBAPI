using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMVC.ClasesAuxiliares;

namespace WebMVC.Controllers
{
    public class UsuariosController : Controller
    {
        public string UrlApi { get; set; }

        public UsuariosController(IConfiguration config)
        {
            UrlApi = config.GetValue<string>("UrlAPI") + "Usuarios/";
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDTO usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HttpClient client = new HttpClient();
                    string url = UrlApi + "Login";
                    var tarea = client.PostAsJsonAsync(url, usuario);
                    tarea.Wait();
                    var respuesta = tarea.Result;
                    string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    if (respuesta.IsSuccessStatusCode)
                    {
                        UsuarioLogueadoDTO usuarioLogueado = JsonConvert.DeserializeObject<UsuarioLogueadoDTO>(cuerpo);
                        if (usuarioLogueado != null)
                        {
                            HttpContext.Session.SetString("EmailUsuario", usuarioLogueado.EmailUsuario);
                            HttpContext.Session.SetString("RolUsuario", usuarioLogueado.RolUsuario);
                            HttpContext.Session.SetString("Token", usuarioLogueado.Token);
                            return RedirectToAction("ListarMovimientosStock", "MovimientoStock");
                        }
                        ViewBag.Mensaje = "Email o Contraseña incorrectos";
                    }
                    else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest
                        || (int)respuesta.StatusCode == StatusCodes.Status404NotFound
                        || (int)respuesta.StatusCode == StatusCodes.Status500InternalServerError)
                    {
                        ViewBag.Mensaje = cuerpo;
                    }
                    else
                    {
                        ViewBag.Mensaje = "Ha ocurrido un error";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Error, debe ingresar Email y Contraseña";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Error interno. Inténtelo mas tarde";
            }
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                if (!string.IsNullOrEmpty(token))
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Mensaje = "Error al cerrar sesión";
                    return View("Index");
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Error interno. Inténtelo más tarde.";
                return View("Index");
            }
        }
    }
}