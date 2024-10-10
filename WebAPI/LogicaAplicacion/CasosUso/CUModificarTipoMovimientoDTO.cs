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
    public class CUModificarTipoMovimientoDTO : ICUModificar<TipoMovimientoDTO>
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUModificarTipoMovimientoDTO(IRepositorioTipoMovimiento repo)
        {
            Repo= repo;
        }
        public void Update(TipoMovimientoDTO obj)
        {
            Repo.Update(MapperTipoMovimiento.ToTipoMovimiento(obj));
        }
    }
}
