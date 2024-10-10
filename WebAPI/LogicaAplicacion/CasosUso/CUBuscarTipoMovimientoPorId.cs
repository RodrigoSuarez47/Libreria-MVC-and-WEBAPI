using DTOs;
using DTOs.MappersDTOs;
using LogiaNegocio.Dominio;
using LogiaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarTipoMovimientoPorId : ICUBuscarPorId<TipoMovimientoDTO>
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUBuscarTipoMovimientoPorId(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }
        public TipoMovimientoDTO GetById(int id)
        {
            return MapperTipoMovimiento.ToTipoMovimientoDTO(Repo.FindById(id));
        }
    }
}
