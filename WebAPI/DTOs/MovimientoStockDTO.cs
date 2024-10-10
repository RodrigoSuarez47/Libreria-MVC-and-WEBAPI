using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MovimientoStockDTO
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int Cantidad { get; set; }
        public string? ArticuloNombre { get; set; }
        public string?  TipoMovimientoNombre { get; set; }
        public string UsuarioEmail { get; set; }
        public int ArticuloId { get; set; }
        public int TipoMovimientoId { get; set; }
    }
}
