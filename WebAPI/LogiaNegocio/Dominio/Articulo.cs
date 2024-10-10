using LogiaNegocio.InterfacesDominio;
using LogiaNegocio.ValueObjects.ArticuloVOs;
using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.Dominio
{
    public class Articulo
    {
        [Key]
        public int Id { get; set; }
        public NombreArticulo Nombre { get; set; }
        public DescripcionArticulo Descripcion { get; set; }
        public CodigoArticulo CodigoArticulo { get; set; }
        public Precio Precio { get; set; }
        public Stock Stock { get; set; }
        public Parametro Parametro { get; set; }
        public int ParametroId { get; set; }
        public void ActualizarStock(int cant, bool esIncremento) 
        {
            if (esIncremento)
            {
                cant = cant + Stock.Valor;
            }
            else 
            {
                cant = Stock.Valor - cant;
            }
            Stock = new Stock(cant);
        }
    }
}
