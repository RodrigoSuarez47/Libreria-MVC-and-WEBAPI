using LogiaNegocio.Dominio;
using LogiaNegocio.ValueObjects.MovimientosStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.MappersDTOs
{
    public class MapperMovimientoStock
    {
        public static MovimientoStock ToMovimiento(MovimientoStockDTO ms)
        {
            DateTime fechaMov = DateTime.Now;
            MovimientoStock movimientoStock = new MovimientoStock()
            {
                Fecha = fechaMov,
                Cantidad = new Cantidad(ms.Cantidad),
                UsuarioEmail = ms.UsuarioEmail,
                Articulo = new Articulo()
                {
                    Id = ms.ArticuloId
                },
                TipoMovimiento = new TipoMovimiento()
                {
                    Id = ms.TipoMovimientoId
                }
            };
            return movimientoStock;
        }
        public static MovimientoStockDTO ToMovimientoStockDTO(MovimientoStock ms)
        {
            MovimientoStockDTO movimientoStockDTO = new MovimientoStockDTO()
            {
                Id = ms.Id,
                FechaMovimiento = ms.Fecha,
                Cantidad = ms.Cantidad.Valor,
                ArticuloId = ms.Articulo.Id,
                TipoMovimientoId = ms.TipoMovimientoId,
                UsuarioEmail = ms.UsuarioEmail
            };
            return movimientoStockDTO;
        }
        public static IEnumerable<MovimientoStockDTO> ToListMovimientoDTO(IEnumerable<MovimientoStock> movimientos)
        {
            return movimientos.Select(mov => new MovimientoStockDTO
            {
                Id = mov.Id,
                FechaMovimiento = mov.Fecha,
                Cantidad = mov.Cantidad.Valor,
                ArticuloNombre = mov.Articulo.Nombre.Valor,
                TipoMovimientoNombre = mov.TipoMovimiento.NombreTipoMovimiento.Valor,
                UsuarioEmail = mov.UsuarioEmail,
                ArticuloId = mov.Articulo.Id,
                TipoMovimientoId = mov.TipoMovimientoId,
            });
        }

        public static IEnumerable<MovimientoStock> ToListMovimientoStock(IEnumerable<MovimientoStockDTO> lista)
        {
            return lista.Select(mov => new MovimientoStock
            {
                Fecha = mov.FechaMovimiento,
                Cantidad = new Cantidad(mov.Cantidad),
                UsuarioEmail = mov.UsuarioEmail,
                Articulo = new Articulo()
                {
                    Id = mov.ArticuloId
                },
                TipoMovimiento = new TipoMovimiento()
                {
                    Id = mov.TipoMovimientoId
                }

            });

        }
    }
}