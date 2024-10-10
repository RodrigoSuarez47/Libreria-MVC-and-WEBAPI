using DTOs;
using LogiaNegocio.Dominio;
using LogiaNegocio.ExcepcionesPropias;
using LogiaNegocio.ValueObjects.UsuarioVOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;
using WebAPI.Token;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public ICULoginUsuario LoginUsuario { get; set; }

        public UsuariosController(ICULoginUsuario loginUsuario)
        {
            LoginUsuario = loginUsuario;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO usu)
        {
            if (string.IsNullOrEmpty(usu.Email) || string.IsNullOrEmpty(usu.Contrasena))
                return BadRequest("Ingrese email y contraseña.");
            try
            {
                UsuarioDTO usuario = LoginUsuario.Login(usu.Email, usu.Contrasena);
                if (usuario != null)
                {
                    return Ok(new UsuarioLogueadoDTO()
                    {
                        EmailUsuario = usuario.Email,
                        RolUsuario = usuario.Rol,
                        Token = WebAPI.Token.ManejadorToken.CrearToken(usuario)
                    });
                }
                else
                {
                    return NotFound("Email o Contraseña incorrecto.");
                }
            }
            catch (DatosInvalidosException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Algo salió mal.");
            }
        }
    }
}
