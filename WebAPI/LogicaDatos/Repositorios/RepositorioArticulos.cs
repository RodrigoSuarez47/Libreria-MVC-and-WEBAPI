using LogiaNegocio.Dominio;
using LogiaNegocio.ExcepcionesPropias;
using LogiaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaDatos.Repositorios
{
    public class RepositorioArticulos : IRepositorioArticulos

    {
        public DepositoContext Contexto { get; set; }

        public RepositorioArticulos(DepositoContext contexto)
        {
            Contexto = contexto;
        }
        public IEnumerable<Articulo> FindAll()
        {
            return Contexto.Articulos.Include(a => a.Parametro).ToList();
        }

        public Articulo FindById(int id)
        {
            Articulo art = Contexto.Articulos.Where(a => a.Id == id).Include(a=>a.Parametro).SingleOrDefault();
            if (art == null) throw new Exception("No se encontro el articulo buscado.");
            return art;
        }
    }
}
