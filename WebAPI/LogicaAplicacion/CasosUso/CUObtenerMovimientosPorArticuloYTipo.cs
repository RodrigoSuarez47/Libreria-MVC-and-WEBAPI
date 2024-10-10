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
    public class CUObtenerMovimientosPorArticuloYTipo : ICUObtenerMovimientosPorArticuloYTipo
    {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUObtenerMovimientosPorArticuloYTipo(IRepositorioMovimientosStock repo)
        {
            Repo = repo;
        }

        public IEnumerable<MovimientoStockDTO> ObtenerMovimientosPorArticuloYTipo(int ArticuloId, int TipoMovimientoId, int pagina)
        {
            IEnumerable<MovimientoStock> encontrados = Repo.ObtenerMovimientosPorArticuloYTipo(ArticuloId, TipoMovimientoId, pagina);
            return MapperMovimientoStock.ToListMovimientoDTO(encontrados);
        }

        public IEnumerable<MovimientoStockDTO> ObtenerMovimientosPorArticuloYTipo(int ArticuloId, int TipoMovimientoId)
        {
            IEnumerable<MovimientoStock> encontrados = Repo.ObtenerMovimientosPorArticuloYTipo(ArticuloId, TipoMovimientoId);
            return MapperMovimientoStock.ToListMovimientoDTO(encontrados);
        }
    }
}
