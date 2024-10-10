using LogiaNegocio.InterfacesDominio;
using LogiaNegocio.ValueObjects.UsuarioVOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public EmailUsuario Email { get; set; }
        public NombreUsuario Nombre { get; set; }
        public NombreUsuario Apellido { get; set; }
        public Contrasenia Contrasenia { get; set; }
        public string? ContraseniaEncriptada { get; set; }
    }
}
