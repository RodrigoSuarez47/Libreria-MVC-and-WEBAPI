using LogiaNegocio.Dominio;
using LogiaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuarios 
    { 
        Usuario FindByEmail(string email);

        Usuario Login(string email, string password);
    }
}
