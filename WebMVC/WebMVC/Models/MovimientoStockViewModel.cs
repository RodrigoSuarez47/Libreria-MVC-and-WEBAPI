using System.ComponentModel;

namespace WebMVC.Models
{
    public class MovimientoStockViewModel
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Movimiento")]
        public DateTime FechaMovimiento { get; set; }
        public int Cantidad { get; set; }
        [DisplayName("Articulo")]
        public int ArticuloId { get; set; }
        [DisplayName("Email Usuario")]
        public string UsuarioEmail { get; set; }
        [DisplayName("Tipo de Movimiento")]
        public int TipoMovimientoId { get; set; }

    }
}
