using LogiaNegocio.Dominio;
using LogiaNegocio.InterfacesDominio;
using LogicaNegocio.ValueObjects.ParametroArticulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Dominio
{
    public class Parametro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ParametroValor Valor { get; set; }

    }
}
