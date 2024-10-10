using DTOs;
using LogiaNegocio.ExcepcionesPropias;
using LogicaAplicacion.InterfacesCU;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMovimientosController : ControllerBase
    {
        public ICUListar<TipoMovimientoDTO> CUListarTiposMovimientos { get; set; }
        public ICUBuscarPorId<TipoMovimientoDTO> CUBuscarTipoMovimientoPorID { get; set; }
        public ICUModificar<TipoMovimientoDTO> CUActualizarTipoMovimientoPorID { get; set; }
        public ICUBaja CUBaja { get; set; }
        public ICUAlta<TipoMovimientoDTO> CUAltaTipoMovimientoDTO { get; set; }
        public TipoMovimientosController(ICUListar<TipoMovimientoDTO> cuListarTiposMovimientos, ICUBuscarPorId<TipoMovimientoDTO> cuBuscarTipoMovimientoPorID, 
            ICUModificar<TipoMovimientoDTO> cuActualizarTipoMovimientoPorID, ICUBaja cuBaja, ICUAlta<TipoMovimientoDTO> cuAltaTipoMovimientoDTO)
        {
            CUListarTiposMovimientos = cuListarTiposMovimientos;
            CUBuscarTipoMovimientoPorID = cuBuscarTipoMovimientoPorID;
            CUActualizarTipoMovimientoPorID = cuActualizarTipoMovimientoPorID;
            CUBaja = cuBaja;
            CUAltaTipoMovimientoDTO = cuAltaTipoMovimientoDTO;
        }

        [HttpGet]
        public IActionResult Get() {
            IEnumerable<TipoMovimientoDTO> tipoMovimientos = CUListarTiposMovimientos.Listar();
            return Ok(tipoMovimientos);
        }
        // GET api/<TipoMovimientosController>/5
        [HttpGet("{id}", Name = "BuscarPorId")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("El id del tipo de movimiento deber ser un entero positivo");
            try
            {
                TipoMovimientoDTO tp = CUBuscarTipoMovimientoPorID.GetById(id);
                return Ok(tp);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Error inesperado");
            }
        }

        // POST api/<TipoMovimientosController>
        [HttpPost]
        public IActionResult Post([FromBody] TipoMovimientoDTO tpDTO)
        {
            if (tpDTO == null) return BadRequest("Se proporcionaron datos inválidos.");
            try
            {
                CUAltaTipoMovimientoDTO.Alta(tpDTO);
                return CreatedAtRoute("BuscarPorId", new { id = tpDTO.Id }, tpDTO);
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception) 
            {
                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }
        

        // PUT api/<TipoMovimientosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TipoMovimientoDTO tpDTO)
        {
            if(id <= 0) return BadRequest("El id del tipo de movimiento deber ser un entero positivo.");
            if (tpDTO == null) return BadRequest("Datos a actualizar inválidos.");
            if (id != tpDTO.Id) return BadRequest("No se proporcionaron los id correctos.");
            try
            {
                CUActualizarTipoMovimientoPorID.Update(tpDTO);
                return Ok();
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Error inesperado.");
            }
        }

        // DELETE api/<TipoMovimientosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest("El id del tipo de movimiento proporcionado deber ser un entero positivo");
            try
            {
                CUBaja.Baja(id);
                return Ok();
            }
            catch (DatosInvalidosException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error inesperado. Intente mas tarde");
            }
        }
    }
}
