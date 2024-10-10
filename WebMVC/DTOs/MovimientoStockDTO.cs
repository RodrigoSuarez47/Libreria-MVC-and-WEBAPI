using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MovimientoStockDTO
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Movimiento")]
        public DateTime FechaMovimiento { get; set; }
        public int Cantidad { get; set; }
        [DisplayName("Articulo")]
        public string ArticuloNombre { get; set; }
        [DisplayName("Email Usuario")]
        public string UsuarioEmail { get; set; }
        [DisplayName("Tipo de Movimiento")]
        public string  TipoMovimientoNombre { get; set; }
        public int ArticuloId { get; set; }
        public int TipoMovimientoId { get; set; }

    }
}
