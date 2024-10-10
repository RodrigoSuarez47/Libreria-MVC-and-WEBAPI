using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MovimientoStockListDTO
    {
        public int Id { get; set; }
        public DateTime? FechaMovimiento { get; set; }
        public int Cantidad { get; set; }
        public string ArticuloNombre { get; set; }
        public string UsuarioEmail { get; set; }
        public string TipoMovimientoNombre { get; set; }
    }
}
