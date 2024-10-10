using LogiaNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.ArticuloVOs
{
    public class Precio
    {
        public decimal Valor { get; init; }
        private Precio() { }
        public Precio(decimal valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (Valor <= 0) throw new DatosInvalidosException("El precio no puede ser inferior o igual a 0.");
        }
        public override bool Equals(object? obj)
        {
            Precio otro = obj as Precio;
            if (otro == null) return false;
            return otro.Valor == Valor;
        }
    }
}
