using DTOs;
using DTOs.MappersDTOs;
using LogiaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBuscarMovimientoStockPorId : ICUBuscarPorId<MovimientoStockDTO>
    {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUBuscarMovimientoStockPorId(IRepositorioMovimientosStock repo)
        {
            Repo = repo;
        }
        public MovimientoStockDTO GetById(int id)
        {
            return MapperMovimientoStock.ToMovimientoStockDTO(Repo.FindById(id));
        }
    }
}
