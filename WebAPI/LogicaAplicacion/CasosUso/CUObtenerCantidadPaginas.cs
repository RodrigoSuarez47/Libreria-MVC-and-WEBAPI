using DTOs;
using DTOs.MappersDTOs;
using LogiaNegocio.Dominio;
using LogiaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUObtenerCantidadPaginas : ICUObtenerCantidadPaginas
    {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUObtenerCantidadPaginas(IRepositorioMovimientosStock repo)
        {
            Repo = repo;
        }

        public double ObtenerCantidadPaginas(int totalMovimientos)
        {
            return Repo.ObtenerCantidadPaginas(totalMovimientos);
        }
    }
}
