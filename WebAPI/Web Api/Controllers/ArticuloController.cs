using DTOs;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        public ICUListar<ArticuloDTO> CUListarArticulosDTO { get; set; }
        public ArticuloController(ICUListar<ArticuloDTO> cuListarArticulosDTO)
        {
            CUListarArticulosDTO = cuListarArticulosDTO;
        }
        // GET: api/<ArticuloController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<ArticuloDTO> articulos = CUListarArticulosDTO.Listar();
                if (!articulos.Any()) return NotFound("No se encontraron artículos.");
                return Ok(articulos);
            }
            catch 
            {
                return StatusCode(500, "Error inesperado.");
            }            
        }
    }
}
