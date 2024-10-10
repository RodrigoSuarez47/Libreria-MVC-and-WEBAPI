using DTOs;
using DTOs.MappersDTOs;
using LogiaNegocio.Dominio;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListarTiposMovimientosDTO : ICUListar<TipoMovimientoDTO>
    {
        public IRepositorioTipoMovimiento Repo { get; set; }

        public CUListarTiposMovimientosDTO(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }

        public IEnumerable<TipoMovimientoDTO> Listar()
        {
            IEnumerable<TipoMovimiento> tipoMovimientos = Repo.FindAll();
            return MapperTipoMovimiento.ToListTipoMovimientoDTO(tipoMovimientos);
        }
    }
}
