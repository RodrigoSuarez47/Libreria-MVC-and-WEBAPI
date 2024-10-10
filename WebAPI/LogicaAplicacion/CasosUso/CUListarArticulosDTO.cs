using DTOs;
using DTOs.MappersDTOs;
using LogiaNegocio.Dominio;
using LogiaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListarArticulosDTO : ICUListar<ArticuloDTO>
    {
        public IRepositorioArticulos Repo { get; set; }
        public CUListarArticulosDTO(IRepositorioArticulos repo)
        {
            Repo = repo;
        }
        public IEnumerable<ArticuloDTO> Listar()
        {
            IEnumerable<Articulo> articulos = Repo.FindAll();
            return MapperArticulo.ToListDtoSimple(articulos);
        }
    }
}
