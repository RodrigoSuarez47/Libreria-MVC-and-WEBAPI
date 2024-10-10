using DTOs;
using DTOs.MappersDTOs;
using LogiaNegocio.Dominio;
using LogiaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUListarMovimientosDTO : ICUListar<MovimientoStockDTO>
    {
        public IRepositorioMovimientosStock Repo { get; set; }
        public CUListarMovimientosDTO(IRepositorioMovimientosStock repo)
        {
            Repo = repo;
        }
        public IEnumerable<MovimientoStockDTO> Listar()
        {
            IEnumerable<MovimientoStock> movimientosStock = Repo.FindAll();
            IEnumerable<MovimientoStockDTO> movimientosStockDTO = MapperMovimientoStock.ToListMovimientoDTO(movimientosStock);
            return movimientosStockDTO;
        }
    }
}
