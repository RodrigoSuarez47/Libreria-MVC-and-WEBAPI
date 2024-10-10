using LogiaNegocio.ExcepcionesPropias;
using LogiaNegocio.InterfacesDominio;
using LogiaNegocio.ValueObjects.ArticuloVOs;
using LogiaNegocio.ValueObjects.MovimientosStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.Dominio
{
    public class MovimientoStock
    {
        public int Id { get; set; }
        public int TipoMovimientoId { get; set; }
        public Cantidad Cantidad { get; set; }
        public string UsuarioEmail { get; set; }
        public Articulo Articulo { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public void CalcularMovimientoStock(int cant) 
        {
            if (cant <= 0) 
                throw new DatosInvalidosException("Solo se pueden mover cantidad de articulos con numeros enteros positivos.");
            if (cant > Articulo.Parametro.Valor.Valor)
                throw new DatosInvalidosException($"No se pueden mover más {Articulo.Nombre.Valor} de los permitido por el límite de movimiento. El  tope es {Articulo.Parametro.Valor.Valor}");
            if (!TipoMovimiento.EsIncremento) 
            {
                if (cant > Articulo.Stock.Valor) 
                    throw new DatosInvalidosException($"No hay articulos suficientes. Solo contamos {Articulo.Stock.Valor}");
                if (cant > Articulo.Stock.Valor && Articulo.Stock.Valor - cant < 0) 
                    throw new DatosInvalidosException($"No hay articulos suficientes. Solo contamos {Articulo.Stock.Valor}");            
            }
            Articulo.ActualizarStock(cant, TipoMovimiento.EsIncremento);
        }
    }
}
