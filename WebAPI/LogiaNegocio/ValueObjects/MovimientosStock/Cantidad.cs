using LogiaNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.MovimientosStock
{
    public class Cantidad
    {
        public int Valor { get; init; }
        private Cantidad() { }
        public Cantidad(int valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if(Valor <=0)throw new DatosInvalidosException("Únicamente se permiten movimientos con números naturales positivos.");
        }
        public override bool Equals(object? obj)
        {
            Cantidad otra = obj as Cantidad;
            if(otra == null) return false;
            return otra.Valor == Valor;
        }
    }
}
