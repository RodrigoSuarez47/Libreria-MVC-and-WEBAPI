using LogicaAplicacion.InterfacesCU;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class CUBajaTipoMovimientoDTO : ICUBaja
    {
        public IRepositorioTipoMovimiento Repo { get; set; }
        public CUBajaTipoMovimientoDTO(IRepositorioTipoMovimiento repo)
        {
            Repo = repo;
        }
        public void Baja(int id)
        {
            Repo.Remove(id);
        }
    }
}
