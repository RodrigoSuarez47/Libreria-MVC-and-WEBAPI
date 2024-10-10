using DTOs;
using DTOs.MappersDTOs;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaTipoMovimientoDTO : ICUAlta<TipoMovimientoDTO>
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUAltaTipoMovimientoDTO(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }
        public void Alta(TipoMovimientoDTO obj)
        {
            Repo.Add(MapperTipoMovimiento.ToTipoMovimiento(obj));
        }
    }
}
