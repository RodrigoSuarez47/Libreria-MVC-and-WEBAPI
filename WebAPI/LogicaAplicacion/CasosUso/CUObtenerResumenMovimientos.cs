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
    public class CUObtenerResumenMovimientos : ICUObtenerResumenMovimientos
    {
        public IRepositorioMovimientosStock Repo {  get; set; }

        public CUObtenerResumenMovimientos(IRepositorioMovimientosStock repo)
        {
            Repo = repo;
        }

        public string ObtenerResumenMovimientos()
        {
            return Repo.ObtenerResumenMovimientos();
        }
    }
}
