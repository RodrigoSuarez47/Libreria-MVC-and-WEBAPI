using DTOs;

namespace WebMVC.Models
{
    public class MovimientoConsultaViewModel
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int ArticuloId { get; set; }
        public int MovimientoId { get; set; }
        public IEnumerable<ArticuloDTO> Articulos { get; set; }
        public IEnumerable<TipoMovimientoDTO> TiposMovimiento { get; set; }
        public IEnumerable <MovimientoStockDTO> Movimientos { get; set; }

    }
}
