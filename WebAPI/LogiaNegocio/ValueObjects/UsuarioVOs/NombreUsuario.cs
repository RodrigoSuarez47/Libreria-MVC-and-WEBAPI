using LogiaNegocio.ExcepcionesPropias;
using LogiaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.UsuarioVOs
{
    public class NombreUsuario
    {
        [MaxLength(100)]
        [MinLength(3, ErrorMessage = "El nombre debe contener al menos 3 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+([' -][a-zA-Z]+)*$", ErrorMessage = "La cadena debe contener solo caracteres alfabéticos, " +
        "espacios, apóstrofes o guiones del medio, sin caracteres no alfabéticos al principio o al final.")]
        public string Valor { get; init; }
        private NombreUsuario() { }
        public NombreUsuario(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor)) throw new DatosInvalidosException("El nombre de usuario no puede estar vacio.");
        }
        public override bool Equals(object? obj)
        {
            NombreUsuario otro = obj as NombreUsuario;
            if (otro == null) return false;
            return otro.Valor == Valor;
        }
    }
}
