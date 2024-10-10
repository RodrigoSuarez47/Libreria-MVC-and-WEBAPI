using LogiaNegocio.Dominio;
using LogiaNegocio.ValueObjects.ArticuloVOs;
using LogiaNegocio.ValueObjects.TipoMovimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DTOs.MappersDTOs
{
    public static class MapperTipoMovimiento
    {
        public static IEnumerable<TipoMovimientoDTO> ToListTipoMovimientoDTO(IEnumerable<TipoMovimiento> tipoMovimientos)
        {
            return tipoMovimientos.Select(tm => new TipoMovimientoDTO
            {
                Id = tm.Id,
                Nombre = tm.NombreTipoMovimiento.Valor,
                EsIncremento = tm.EsIncremento
            });
        }
        public static TipoMovimientoDTO ToTipoMovimientoDTO(TipoMovimiento tp)
        {
            if (tp != null)
            {
            TipoMovimientoDTO tipoMovimientoDTO = new TipoMovimientoDTO()
            {
                Id = tp.Id,
                Nombre = tp.NombreTipoMovimiento.Valor,
                EsIncremento = tp.EsIncremento
            };
            return tipoMovimientoDTO;
            }
            return null;

        }
        public static TipoMovimiento ToTipoMovimiento(TipoMovimientoDTO tpDTO)
        {
            TipoMovimiento tipoMovimiento = new TipoMovimiento()
            {
                NombreTipoMovimiento = new NombreTipoMovimiento(tpDTO.Nombre),
                EsIncremento = tpDTO.EsIncremento,
                Id = tpDTO.Id
            };
            return tipoMovimiento;
        }
    }

}
