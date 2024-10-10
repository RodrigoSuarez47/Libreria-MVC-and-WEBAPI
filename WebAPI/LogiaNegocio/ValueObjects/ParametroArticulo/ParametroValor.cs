using LogiaNegocio.ExcepcionesPropias;
using LogiaNegocio.ValueObjects.MovimientosStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObjects.ParametroArticulo
{
    public class ParametroValor
    {
        public int Valor { get; init; }
        private ParametroValor() { }
        public ParametroValor(int valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (Valor <= 0) throw new DatosInvalidosException("Únicamente se permiten topes de movimientos con números valores iguales o inferiores a 0.");
        }
        public override bool Equals(object? obj)
        {
            ParametroValor otra = obj as ParametroValor;
            if (otra == null) return false;
            return otra.Valor == Valor;
        }
    }
}
