using DTOs;
using LogiaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU
{
    public interface ICUObtenerMovimientosPorArticuloYTipo
    {
        IEnumerable<MovimientoStockDTO> ObtenerMovimientosPorArticuloYTipo(int ArticuloId, int TipoMovimientoId);
        IEnumerable<MovimientoStockDTO> ObtenerMovimientosPorArticuloYTipo(int ArticuloId, int TipoMovimientoId, int pagina);
    }
}
