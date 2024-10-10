using LogiaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.InterfacesRepositorios
{
    public interface IRepositorioMovimientosStock
    {
        MovimientoStock FindById(int id);
        IEnumerable<MovimientoStock> FindAll();
        void Add(MovimientoStock obj);
        IEnumerable<MovimientoStock> ObtenerMovimientosPorArticuloYTipo(int articuloId, int tipoMovimiento);
        IEnumerable<MovimientoStock> ObtenerMovimientosPorArticuloYTipo(int articuloId, int tipoMovimiento, int pagina);
        IEnumerable<MovimientoStock> ObtenerMovimientosPorRangoDeFechas(DateTime inicio, DateTime fin);
        IEnumerable<MovimientoStock> ObtenerMovimientosPorRangoDeFechas(DateTime inicio, DateTime fin, int pagina);
        public string ObtenerResumenMovimientos();
        public double ObtenerCantidadPaginas(int totalMovimientos);
    }
}
