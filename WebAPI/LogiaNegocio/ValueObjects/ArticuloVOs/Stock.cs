using LogiaNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.ArticuloVOs
{
    public class Stock
    {
        public int Valor { get; init; }
        private Stock() { }
        public Stock(int valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (Valor < 0) throw new DatosInvalidosException("El stock no puede ser inferior a 0.");
        }
        public override bool Equals(object? obj)
        {
            Stock otro = obj as Stock;
            if (otro == null) return false;
            return otro.Valor == Valor;
        }
    }
}
