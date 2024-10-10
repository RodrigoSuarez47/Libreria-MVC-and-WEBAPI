using DTOs;
using LogiaNegocio.Dominio;
using LogiaNegocio.ExcepcionesPropias;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoStockController : ControllerBase
    {
        public ICUListar<MovimientoStockDTO> CUListarMovimientos { get; set; }
        public ICUAlta<MovimientoStockDTO> CUAltaMovimientoStock { get; set; }
        public ICUBuscarPorId<MovimientoStockDTO> CUBuscarPorId { get; set; }
        public ICUObtenerMovimientosPorArticuloYTipo CUObtenerMovimientosPorArticuloYTipo { get; set; }
        public ICUObtenerMovimientosPorRangoDeFechas CUObtenerMovimientosPorRangoDeFechas { get; set; }
        public ICUObtenerResumenMovimientos CUObtenerResumenMovimientos { get; set; }
        public ICUObtenerCantidadPaginas CUObtenerCantidadPaginas { get; set; }


        public MovimientoStockController(ICUListar<MovimientoStockDTO> cuListarMovimientos,
            ICUAlta<MovimientoStockDTO> cuAltaMovimientoStock, 
            ICUBuscarPorId<MovimientoStockDTO> cuBuscarPorId,
            ICUObtenerMovimientosPorArticuloYTipo cuObtenerMovimientosPorAticuloyTipo,
            ICUObtenerMovimientosPorRangoDeFechas cuObtenerMovimientosPorRangoDeFechas, 
            ICUObtenerResumenMovimientos cuObtenerResumenMovimientos,
            ICUObtenerCantidadPaginas cuObtenerCantidadPaginas)
        {
            CUAltaMovimientoStock = cuAltaMovimientoStock;
            CUBuscarPorId = cuBuscarPorId;
            CUListarMovimientos = cuListarMovimientos;
            CUObtenerMovimientosPorArticuloYTipo = cuObtenerMovimientosPorAticuloyTipo;
            CUObtenerMovimientosPorRangoDeFechas = cuObtenerMovimientosPorRangoDeFechas;
            CUObtenerResumenMovimientos = cuObtenerResumenMovimientos;
            CUObtenerCantidadPaginas = cuObtenerCantidadPaginas;
        }
        // GET: api/<MovimientoStockController>
        [HttpGet]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult Get()
        {
            IEnumerable<MovimientoStockDTO> movimientos = CUListarMovimientos.Listar();
            return Ok(movimientos);
        }

        // GET api/<MovimientoStockController>/5
        [HttpGet("{id}", Name= "BuscarPorIdMovimientoStock")]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("No se pueden ingresar id menor o igual a 0.");
            return Ok(CUBuscarPorId.GetById(id));
        }

        // POST api/<MovimientoStockController>
        [HttpPost]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult Post([FromBody] MovimientoStockDTO msDTO)
        {
            if (msDTO == null) return BadRequest("Los datos proporcionados son inválidos");
            if (msDTO.ArticuloId == 0 || msDTO.TipoMovimientoId == 0) return BadRequest("No se ingresaron datos de articulo o tipo de movimiento.");
            try
            {
                CUAltaMovimientoStock.Alta(msDTO);
                int nuevoId = msDTO.Id;
                return CreatedAtRoute("BuscarPorIdMovimientoStock", new { id = nuevoId }, msDTO);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error inesperado.");
            }
        }

        [HttpGet("articulo/{ArticuloId}/tipo/{MovimientoId}")]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult ConsultarMovimientosPorArticuloYTipo(int ArticuloId, int MovimientoId)
        {
            if (ArticuloId <= 0) return BadRequest("Seleccione el Articulo");
            if (MovimientoId <= 0) return BadRequest("Seleccione el Tipo de Movimiento");
            try
            {
                var movimientos = CUObtenerMovimientosPorArticuloYTipo.ObtenerMovimientosPorArticuloYTipo(ArticuloId, MovimientoId);
                return Ok(movimientos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error inesperado.");
            }
        }

        [HttpGet("articulo/{ArticuloId}/tipo/{MovimientoId}/pagina{pagina}")]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult ConsultarMovimientosPorArticuloYTipo(int ArticuloId, int MovimientoId, int pagina)
        {
            if (ArticuloId <= 0) return BadRequest("Seleccione el Articulo");
            if (MovimientoId <= 0) return BadRequest("Seleccione el Tipo de Movimiento");
            if (pagina == null || pagina <= 0)
            {
                var movimientos = CUObtenerMovimientosPorArticuloYTipo.ObtenerMovimientosPorArticuloYTipo(ArticuloId, MovimientoId, 1);
                return Ok(movimientos);
            }
            else
            {
                var movimientos = CUObtenerMovimientosPorArticuloYTipo.ObtenerMovimientosPorArticuloYTipo(ArticuloId, MovimientoId, pagina);
                return Ok(movimientos);
            }
        }

        [HttpGet("fechaInicio{fechaInicio}/fechaFin{fechaFin}")]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult ConsultarMovimientosPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio == null || fechaFin == null) return BadRequest("Ingrese Fecha de Inicio y Fecha de Fin");
            if (fechaInicio > fechaFin) return BadRequest("La Fecha de Inicio no puede ser mayor que la Fecha de Fin");
            try
            {
                var articulos = CUObtenerMovimientosPorRangoDeFechas.ObtenerMovimientosPorRangoFechas(fechaInicio, fechaFin);
                return Ok(articulos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno.");
            }
        }

        [HttpGet("fechaInicio{fechaInicio}/fechaFin{fechaFin}/pagina{pagina}")]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult ConsultarMovimientosPorFecha(DateTime fechaInicio, DateTime fechaFin, int pagina)
        {
            if (fechaInicio == null || fechaFin == null) return BadRequest("Ingrese Fecha de Inicio y Fecha de Fin");
            if (fechaInicio > fechaFin) return BadRequest("La Fecha de Inicio no puede ser mayor que la Fecha de Fin");
            if (pagina == null || pagina <= 0)
            {
                var articulos = CUObtenerMovimientosPorRangoDeFechas.ObtenerMovimientosPorRangoFechas(fechaInicio, fechaFin, 1);
                return Ok(articulos);
            } 
            else
            {
                var articulos = CUObtenerMovimientosPorRangoDeFechas.ObtenerMovimientosPorRangoFechas(fechaInicio, fechaFin, pagina);
                return Ok(articulos);
            }
        }

        [HttpGet("resumen")]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult ObtenerResumenMovimientos()
        {
            var resumen = CUObtenerResumenMovimientos.ObtenerResumenMovimientos();
            return Ok(resumen);
        }

        [HttpGet("cantidadPaginas/{totalMovimientos}")]
        [Authorize(Roles = "EncargadoDeposito")]
        public IActionResult ObtenerCantidadPaginas(int totalMovimientos)
        {
            try
            {
                var resultado = CUObtenerCantidadPaginas.ObtenerCantidadPaginas(totalMovimientos);
                return Ok(resultado);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

    }
}

