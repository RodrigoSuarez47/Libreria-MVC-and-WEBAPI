using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long CodigoArticulo {  get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int TopeDeArticuloPorMovimiento { get; set; }
    }
}
