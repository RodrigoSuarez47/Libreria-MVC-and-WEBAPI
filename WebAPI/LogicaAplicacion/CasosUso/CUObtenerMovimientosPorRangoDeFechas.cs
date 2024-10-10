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
    public class CUObtenerMovimientosPorRangoDeFechas : ICUObtenerMovimientosPorRangoDeFechas
    {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUObtenerMovimientosPorRangoDeFechas(IRepositorioMovimientosStock repo)
        {
            Repo = repo;
        }
        public IEnumerable<MovimientoStockDTO> ObtenerMovimientosPorRangoFechas(DateTime inicio, DateTime fin, int pagina)
        {
            IEnumerable<MovimientoStock> encontrados = Repo.ObtenerMovimientosPorRangoDeFechas(inicio, fin, pagina);
            return MapperMovimientoStock.ToListMovimientoDTO(encontrados);
        }

        public IEnumerable<MovimientoStockDTO> ObtenerMovimientosPorRangoFechas(DateTime inicio, DateTime fin)
        {
            IEnumerable<MovimientoStock> encontrados = Repo.ObtenerMovimientosPorRangoDeFechas(inicio, fin);
            return MapperMovimientoStock.ToListMovimientoDTO(encontrados);
        }
    }
}
