using DTOs;
using DTOs.MappersDTOs;
using LogiaNegocio.Dominio;
using LogiaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUAltaMovimientoStockDTO : ICUAlta<MovimientoStockDTO>
    {
        public IRepositorioMovimientosStock Repo { get; set; }
        public IRepositorioArticulos RepoArt {  get; set; }
        public IRepositorioTipoMovimiento RepoTipoMov {  get; set; }
        public CUAltaMovimientoStockDTO(IRepositorioMovimientosStock repo, IRepositorioArticulos repoArt,
            IRepositorioTipoMovimiento repoTipoMov)
        {
            Repo = repo;
            RepoArt = repoArt;
            RepoTipoMov = repoTipoMov;
        }
        public void Alta(MovimientoStockDTO obj)
        {
            MovimientoStock ms = MapperMovimientoStock.ToMovimiento(obj);
            ms.Articulo = RepoArt.FindById(obj.ArticuloId);
            ms.TipoMovimiento = RepoTipoMov.FindById(obj.TipoMovimientoId);
            ms.CalcularMovimientoStock(obj.Cantidad);
            Repo.Add(ms);            
        }
    }
}
