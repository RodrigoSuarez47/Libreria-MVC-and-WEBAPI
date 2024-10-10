using LogiaNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.ArticuloVOs
{
    public class NombreArticulo
    {
        public string Valor { get; init; }
        private NombreArticulo() { }
        public NombreArticulo(string valor)
        {
            Valor = valor;
            Validar();
        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor)) throw new DatosInvalidosException("El nombre de articulo no puede estar vacio.");
            if (Valor.Length < 3) throw new DatosInvalidosException("El nombre no puede tener menos de 3 caracteres.");
        }
        public override bool Equals(object? obj)
        {
            NombreArticulo otro = obj as NombreArticulo;
            if (otro == null) return false;
            return otro.Valor == Valor;
        }
    }
}
