using LogiaNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.ArticuloVOs
{
    public class CodigoArticulo
    {
        public long Valor { get; init; }
        private CodigoArticulo() { }
        public CodigoArticulo(long valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (Valor <= 0) throw new DatosInvalidosException("EL codigo no puede ser menor a 0.");
            if (Valor == 0) throw new DatosInvalidosException("El codigo de articulo no puede estar vacio.");
            string cantValor = Valor.ToString();
            if (cantValor.Length != 13) throw new DatosInvalidosException("El codigo de articulo debe tener 13 digitos.");
        }
        public override bool Equals(object? obj)
        {
            CodigoArticulo otro = obj as CodigoArticulo;
            if (otro == null) return false;
            return otro.Valor == Valor;
        }
    }
}
