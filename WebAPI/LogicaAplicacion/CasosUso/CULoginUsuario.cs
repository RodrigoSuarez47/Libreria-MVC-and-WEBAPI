using DTOs;
using DTOs.MappersDTOs;
using LogiaNegocio.Dominio;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class CULoginUsuario : ICULoginUsuario
    {
        private readonly IRepositorioUsuarios Repositorio;

        public CULoginUsuario(IRepositorioUsuarios repositorio)
        {
            Repositorio = repositorio;
        }

        public UsuarioDTO Login(string email, string contrasena)
        {
            Usuario usu = Repositorio.Login(email, contrasena);
            UsuarioDTO usuDTO = MapperUsuario.ToUsuarioDTO(usu);
            return usuDTO;
        }
    }
}
