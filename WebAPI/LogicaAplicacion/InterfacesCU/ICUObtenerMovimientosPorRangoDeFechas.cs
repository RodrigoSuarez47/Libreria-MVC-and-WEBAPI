using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICUObtenerMovimientosPorRangoDeFechas
    {
        IEnumerable<MovimientoStockDTO> ObtenerMovimientosPorRangoFechas(DateTime inicio, DateTime fin, int pagina);
        IEnumerable<MovimientoStockDTO> ObtenerMovimientosPorRangoFechas(DateTime inicio, DateTime fin);
    }
}
