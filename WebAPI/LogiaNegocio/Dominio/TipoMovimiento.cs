using LogiaNegocio.InterfacesDominio;
using LogiaNegocio.ValueObjects.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.Dominio
{
    public class TipoMovimiento
    {
        [Key]
        public int Id { get; set;}
        public NombreTipoMovimiento NombreTipoMovimiento {  get; set; }
        public bool EsIncremento { get; set; }
        public IEnumerable<MovimientoStock> MovimientosStock { get; set; }
    }
}
