using LogiaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MappersDTOs
{
    public class MapperArticulo
    {
        public static IEnumerable<ArticuloDTO> ToListDtoSimple(IEnumerable<Articulo> articulos)
        {
            return articulos.Select(a => new ArticuloDTO()
            {
                Id = a.Id,
                Nombre = a.Nombre.Valor,
                Descripcion = a.Descripcion.Valor,
                CodigoArticulo = a.CodigoArticulo.Valor,
                Precio = a.Precio.Valor,
                Stock = a.Stock.Valor,
                //TopeDeArticuloPorMovimiento = a.Parametro.TopeMovimiento.Valor  PARA AREGLAR DESPUES DE CREAR TOPES
            })
            .ToList();
        }
    }
}
