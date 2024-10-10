using DTOs;
using LogiaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICULoginUsuario
    {
        UsuarioDTO Login(string email, string contrasena);
    }
}
