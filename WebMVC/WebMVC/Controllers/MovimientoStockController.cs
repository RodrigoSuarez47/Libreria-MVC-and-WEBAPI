using DTOs;
using WebMVC.Filtro;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using WebMVC.ClasesAuxiliares;
using WebMVC.Models;
using Humanizer;
using System.Reflection;
using NuGet.Protocol;
using System.Linq.Expressions;

namespace WebMVC.Controllers
{
    public class MovimientoStockController : Controller
    {
        public string UrlApi { get; set; }
        public HttpClient client = new HttpClient();

        public MovimientoStockController(IConfiguration config)
        {
            UrlApi = config.GetValue<string>("UrlAPI");
        }
        // GET: MovimientoStockController/ListarMovimientosStock
        [HttpGet]
        [EncargadoDeposito]
        public ActionResult ListarMovimientosStock()
        {
            IEnumerable<MovimientoStockDTO> movimientos = new List<MovimientoStockDTO>();
            try
            {
                string url = UrlApi + "MovimientoStock";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                var tarea1 = client.GetAsync(url);
                tarea1.Wait();
                var respuesta = tarea1.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    movimientos = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(cuerpo);
                }
            }
            catch
            {
                ViewBag.error = "No se encontraron movimientos para mostrar";
            }
            return View(movimientos);
        }
        // GET: MovimientoStockController/Create
        [HttpGet]
        [EncargadoDeposito]
        public ActionResult Create()
        {
            AltaMovimientoStockViewModel vm = new AltaMovimientoStockViewModel();
            vm.ArticuloDTOs = ArticuloDTOs();
            vm.TiposMovimientoDTO = TipoMovimientoDTOs();
            return View(vm);
        }
        // POST: MovimientoStockController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [EncargadoDeposito]
        public ActionResult Create(AltaMovimientoStockViewModel vm)
        {
            try
            {
                MovimientoStockDTO mvDTO = new MovimientoStockDTO()
                {
                    UsuarioEmail = HttpContext.Session.GetString("EmailUsuario"),
                    Cantidad = vm.Cantidad,
                    TipoMovimientoId = vm.TipoMovimientoId,
                    ArticuloId = vm.ArticuloId,
                };
                string url = UrlApi + "MovimientoStock";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                   HttpContext.Session.GetString("Token"));
                var tarea1 = client.PostAsJsonAsync(url, mvDTO);
                tarea1.Wait();
                var respuesta = tarea1.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("ListarMovimientosStock");
                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest
                || (int)respuesta.StatusCode == StatusCodes.Status500InternalServerError)
                {
                    ViewBag.error = respuesta.Content.ReadAsStringAsync().Result;
                }
            }
            catch { }
            vm.TiposMovimientoDTO = TipoMovimientoDTOs();
            vm.ArticuloDTOs = ArticuloDTOs();
            return View(vm);
        }
        [HttpGet]
        public IEnumerable<ArticuloDTO> ArticuloDTOs()
        {
            IEnumerable<ArticuloDTO> articulos = new List<ArticuloDTO>();
            string url = UrlApi + "Articulo";
            var tarea1 = client.GetAsync(url);
            tarea1.Wait();
            var respuesta = tarea1.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                articulos = JsonConvert.DeserializeObject<IEnumerable<ArticuloDTO>>(cuerpo);
            }

            return articulos;
        }
        [HttpGet]
        public IEnumerable<TipoMovimientoDTO> TipoMovimientoDTOs()
        {
            IEnumerable<TipoMovimientoDTO> tipoMovimientos = new List<TipoMovimientoDTO>();
            string url = UrlApi + "TipoMovimientos";
            var tarea1 = client.GetAsync(url);
            tarea1.Wait();
            var respuesta = tarea1.Result;
            if (respuesta.IsSuccessStatusCode)
            {
                string cuerpo = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                tipoMovimientos = JsonConvert.DeserializeObject<IEnumerable<TipoMovimientoDTO>>(cuerpo);
            }
            return tipoMovimientos;
        }
        [HttpGet]
        [EncargadoDeposito]
        public ActionResult ConsultarMovimientosPorFecha()
        {
            var fechaActual = DateTime.Now;
            ViewBag.FechaActual = fechaActual.ToString("yyyy-MM-dd HH:mm:ss");
            return View(new MovimientoConsultaViewModel());
        }
        [HttpPost]
        [EncargadoDeposito]
        public ActionResult ConsultarMovimientosPorFecha(MovimientoConsultaViewModel consulta, int page)
        {
            if (consulta.FechaInicio > consulta.FechaFin)
            {
                ViewBag.Mensaje = "Fecha de Inicio siempre debe ser menor a Fecha de Fin";
                return View();
            }
            try
            {
                IEnumerable<MovimientoStockDTO> movimientosTotales = new List<MovimientoStockDTO>();
                IEnumerable<MovimientoStockDTO> movimientosPagina = new List<MovimientoStockDTO>();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                string url = UrlApi + "MovimientoStock";
                var fechaInicioSinHora = consulta.FechaInicio.ToString("yyyy-MM-dd");
                var fechaFinSinHora = consulta.FechaFin.Date.ToString("yyyy-MM-dd");
                var tarea1 = client.GetAsync(url + $"/fechaInicio{fechaInicioSinHora}/fechaFin{fechaFinSinHora}");
                tarea1.Wait();
                var respuesta = tarea1.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    movimientosTotales = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(contenido);
                    ViewBag.Paginas = ObtenerCantidadPaginas(movimientosTotales);
                    try
                    {
                        var tarea2 = client.GetAsync(url + $"/fechaInicio{fechaInicioSinHora}/fechaFin{fechaFinSinHora}/pagina{page}");
                        tarea2.Wait();
                        var respuesta2 = tarea2.Result;
                        if (respuesta2.IsSuccessStatusCode)
                        {
                            var contenido2 = HerramientasAPI.LeerContenidoRespuesta(respuesta2);
                            movimientosPagina = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(contenido2);
                            MovimientoConsultaViewModel nuevoVM = new MovimientoConsultaViewModel();
                            nuevoVM.Articulos = ArticuloDTOs();
                            nuevoVM.TiposMovimiento = TipoMovimientoDTOs();
                            nuevoVM.Movimientos = movimientosPagina;
                            nuevoVM.FechaInicio = consulta.FechaInicio;
                            nuevoVM.FechaFin = consulta.FechaFin;
                            return View(nuevoVM);
                        }
                        else
                        {
                            ViewBag.Mensaje = "Ha ocurrido un error al obtener los movimientos por pagina";
                        }
                    }
                    catch (Exception) {
                        ViewBag.Mensaje = "Ha ocurrido un error en el servidor";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un error al obtener los movimientos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ha ocurrido un error en el servidor";
            }
            return View(consulta);
        }
        [EncargadoDeposito]
        [HttpGet]
        public ActionResult ConsultarMovimientosPorFechaQuery(string fechaInicio,string fechaFin, int pagina)
        {

            DateTime FechaInicio = DateTime.Parse(fechaInicio);
            DateTime FechaFin = DateTime.Parse(fechaFin);
            if (FechaInicio > FechaFin)
            {
                ViewBag.Mensaje = "Fecha de Inicio siempre debe ser menor a Fecha de Fin";
                return View();
            }
            try
            {
                IEnumerable<MovimientoStockDTO> movimientosTotales = new List<MovimientoStockDTO>();
                IEnumerable<MovimientoStockDTO> movimientosPagina = new List<MovimientoStockDTO>();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                string url = UrlApi + "MovimientoStock";
                var fechaInicioSinHora = FechaInicio.ToString("yyyy-MM-dd");
                var fechaFinSinHora = FechaFin.Date.ToString("yyyy-MM-dd");
                var tarea1 = client.GetAsync(url + $"/fechaInicio{fechaInicioSinHora}/fechaFin{fechaFinSinHora}");
                tarea1.Wait();
                var respuesta = tarea1.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    movimientosTotales = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(contenido);
                    ViewBag.Paginas = ObtenerCantidadPaginas(movimientosTotales);
                    try
                    {
                        var tarea2 = client.GetAsync(url + $"/fechaInicio{fechaInicioSinHora}/fechaFin{fechaFinSinHora}/pagina{pagina}");
                        tarea2.Wait();
                        var respuesta2 = tarea2.Result;
                        if (respuesta2.IsSuccessStatusCode)
                        {
                            var contenido2 = HerramientasAPI.LeerContenidoRespuesta(respuesta2);
                            movimientosPagina = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(contenido2);
                            MovimientoConsultaViewModel nuevoVM = new MovimientoConsultaViewModel();
                            nuevoVM.Articulos = ArticuloDTOs();
                            nuevoVM.TiposMovimiento = TipoMovimientoDTOs();
                            nuevoVM.Movimientos = movimientosPagina;
                            nuevoVM.FechaInicio = FechaInicio;
                            nuevoVM.FechaFin = FechaFin;
                            return View(nuevoVM);
                        }
                        else
                        {
                            ViewBag.Mensaje = "Ha ocurrido un error al obtener los movimientos por pagina";
                        }
                    }
                    catch (Exception)
                    {
                        ViewBag.Mensaje = "Ha ocurrido un error en el servidor";
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un error al obtener los movimientos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ha ocurrido un error en el servidor";
            }
            return View();
        }
        [HttpGet]
        [EncargadoDeposito]
        public ActionResult ConsultarMovimientosPorArticuloYTipo()
        {
            MovimientoConsultaViewModel vm = new MovimientoConsultaViewModel();
            vm.Articulos = ArticuloDTOs();
            vm.TiposMovimiento = TipoMovimientoDTOs();
            return View(vm);
        }
        [HttpPost]
        [EncargadoDeposito]
        public ActionResult ConsultarMovimientosPorArticuloYTipo(MovimientoConsultaViewModel consulta, int page)
        {
            if (page == null || page == 0)
            {
                page = 1;
            }
            try
            {
                IEnumerable<MovimientoStockDTO> movimientosTotales = new List<MovimientoStockDTO>();
                IEnumerable<MovimientoStockDTO> movimientosPagina = new List<MovimientoStockDTO>();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                var tarea1 = client.GetAsync(UrlApi + $"MovimientoStock/articulo/{consulta.ArticuloId}/tipo/{consulta.MovimientoId}");
                tarea1.Wait();
                var respuesta = tarea1.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    movimientosTotales = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(contenido);
                    ViewBag.Paginas = ObtenerCantidadPaginas(movimientosTotales);
                    try
                    {
                        var tarea2 = client.GetAsync(UrlApi + $"MovimientoStock/articulo/{consulta.ArticuloId}/tipo/{consulta.MovimientoId}/pagina{page}");
                        tarea2.Wait();
                        var respuesta2 = tarea2.Result;
                        if (respuesta2.IsSuccessStatusCode)
                        {
                            var contenido2 = HerramientasAPI.LeerContenidoRespuesta(respuesta2);
                            movimientosPagina = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(contenido2);
                            MovimientoConsultaViewModel nuevoVM = new MovimientoConsultaViewModel();
                            nuevoVM.Articulos = ArticuloDTOs();
                            nuevoVM.TiposMovimiento = TipoMovimientoDTOs();
                            nuevoVM.Movimientos = movimientosPagina;
                            nuevoVM.ArticuloId = consulta.ArticuloId;
                            nuevoVM.MovimientoId = consulta.MovimientoId;
                            return View(nuevoVM);
                        }
                        else
                        {
                            ViewBag.Mensaje = "Ha ocurrido un error al obtener los movimientos por pagina";
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un error al obtener los movimientos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ha ocurrido un error en el servidor. Inténtelo mas tarde";
            }
            consulta.Articulos = ArticuloDTOs();
            consulta.TiposMovimiento = TipoMovimientoDTOs();
            return View(consulta);
        }
        [HttpGet]
        [EncargadoDeposito]
        public ActionResult ConsultarMovimientosPorArticuloYTipoQuery(int articulo, int tipo, int pagina)
        {
            MovimientoConsultaViewModel consulta = new MovimientoConsultaViewModel();
            try
            {
                IEnumerable<MovimientoStockDTO> movimientosTotales = new List<MovimientoStockDTO>();
                IEnumerable<MovimientoStockDTO> movimientosPagina = new List<MovimientoStockDTO>();
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                var tarea1 = client.GetAsync(UrlApi + $"MovimientoStock/articulo/{articulo}/tipo/{tipo}");
                tarea1.Wait();
                var respuesta = tarea1.Result;
                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    movimientosTotales = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(contenido);
                    ViewBag.Paginas = ObtenerCantidadPaginas(movimientosTotales);
                    try
                    {
                        var tarea2 = client.GetAsync(UrlApi + $"MovimientoStock/articulo/{articulo}/tipo/{tipo}/pagina{pagina}");
                        tarea2.Wait();
                        var respuesta2 = tarea2.Result;
                        if (respuesta2.IsSuccessStatusCode)
                        {
                            var contenido2 = HerramientasAPI.LeerContenidoRespuesta(respuesta2);
                            movimientosPagina = JsonConvert.DeserializeObject<IEnumerable<MovimientoStockDTO>>(contenido2);
                            MovimientoConsultaViewModel nuevoVM = new MovimientoConsultaViewModel();
                            nuevoVM.Articulos = ArticuloDTOs();
                            nuevoVM.TiposMovimiento = TipoMovimientoDTOs();
                            nuevoVM.Movimientos = movimientosPagina;
                            nuevoVM.ArticuloId = articulo;
                            nuevoVM.MovimientoId = tipo;
                            //return RedirectToAction("ConsultarMovimientosPorArticuloYTipo", nuevoVM);
                            return View(nuevoVM);
                        }
                        else
                        {
                            ViewBag.Mensaje = "Ha ocurrido un error al obtener los movimientos por pagina";
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Ha ocurrido un error al obtener los movimientos";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ha ocurrido un error en el servidor. Inténtelo mas tarde";
            }
            consulta.Articulos = ArticuloDTOs();
            consulta.TiposMovimiento = TipoMovimientoDTOs();
            return View(consulta);
        }
        [HttpGet]
        [EncargadoDeposito]
        public ActionResult ConsultarResumenAnual()
        {
            try
            {
                var client = new HttpClient();
                string url = UrlApi + "MovimientoStock/resumen";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",
                    HttpContext.Session.GetString("Token"));
                var tarea1 = client.GetAsync(url);
                tarea1.Wait();
                var respuesta = tarea1.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    if (contenido.StartsWith("{") || contenido.StartsWith("["))
                    {
                        var resumen = JsonConvert.DeserializeObject<string>(contenido);
                        return View("ConsultarResumenAnual", resumen);
                    }
                    else
                    {
                        return View("ConsultarResumenAnual", contenido);
                    }
                }
                else
                {
                    ViewBag.Mensaje = "No se encontraron movimientos para mostrar";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = "Ocurrió un error en el servidor, no se pudo obtener el resumen";
            }
            return View();
        }
        public double ObtenerCantidadPaginas(IEnumerable<MovimientoStockDTO> lista)
        {
            double cantidadPaginas = 0;
            try
            {
                HttpClient cliente = new HttpClient();
                cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));
                var tarea = cliente.GetAsync(UrlApi + $"MovimientoStock/cantidadPaginas/{lista.Count()}");
                var respuesta = tarea.Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = HerramientasAPI.LeerContenidoRespuesta(respuesta);
                    contenido = contenido.Replace(".", ",");
                    double.TryParse(contenido, out cantidadPaginas);
                    return cantidadPaginas;
                }
                else if ((int)respuesta.StatusCode == StatusCodes.Status400BadRequest || (int)respuesta.StatusCode == StatusCodes.Status500InternalServerError)
                {
                    cantidadPaginas = -1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return cantidadPaginas;
        }
    }
}
