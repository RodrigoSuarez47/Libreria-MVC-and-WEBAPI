using LogiaNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.ArticuloVOs
{
    public class DescripcionArticulo
    {
        public string Valor { get; init; }
        private DescripcionArticulo() { }
        public DescripcionArticulo(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor)) throw new DatosInvalidosException("La descripcion no puede estar vacia.");
            if (Valor.Length < 3) throw new DatosInvalidosException("La descripcion no puede tener menos de 3 caracteres.");
        }
        public override bool Equals(object? obj)
        {
            DescripcionArticulo otro = obj as DescripcionArticulo;
            if (otro == null) return false;
            return otro.Valor == Valor;
        }
    }
}
