using LogiaNegocio.Dominio;
using LogiaNegocio.ExcepcionesPropias;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        public DepositoContext Contexto { get; set; }

        public RepositorioUsuarios(DepositoContext context)
        {
            Contexto = context;
        }
        public Usuario FindByEmail(string email)
        {
            return Contexto.Usuarios.Where(usu => usu.Email.Valor == email).SingleOrDefault();
        }

        public Usuario Login(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))return null;                
                Usuario usuario = FindByEmail(email);
                if (usuario == null || string.IsNullOrEmpty(usuario.ContraseniaEncriptada))
                {
                    return null;
                }
                string storedHashedPassword = usuario.ContraseniaEncriptada;
                bool passwordMatches = BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);
                if (passwordMatches)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new DatosInvalidosException("Error en el proceso de inicio de sesión.");
            }
        }
        public Task Logout(string email)
        {
            throw new NotImplementedException();
        }
    }
}
