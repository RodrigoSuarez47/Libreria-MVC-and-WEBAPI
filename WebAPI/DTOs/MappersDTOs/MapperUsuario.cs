using LogiaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MappersDTOs
{
    public class MapperUsuario
    {
        public static UsuarioDTO ToUsuarioDTO(Usuario usuario)
        {
            if (usuario != null)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO()
                {
                    Nombre = usuario.Nombre.Valor,
                    Apellido = usuario.Apellido.Valor,
                    Email = usuario.Email.Valor,
                    Contrasena = usuario.Contrasenia.Valor,
                    ContrasenaEncriptada = usuario.ContraseniaEncriptada,
                    Rol = usuario.GetType().Name
                };
                return usuarioDTO;
            }
            return null;

        }
    }
}
