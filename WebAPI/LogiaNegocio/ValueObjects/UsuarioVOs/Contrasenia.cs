using LogiaNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.UsuarioVOs
{
    public class Contrasenia
    {
        [MinLength(6, ErrorMessage = "La contraseña debe conter al menos 6 caracteres")]
        [MaxLength(100)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[.,;!])[A-Za-z\d.,;!]+$", ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, una minúscula," +
        " un dígito y un carácter de puntuación: punto, punto y coma, coma o signo de admiración de cierre.")]
        public string Valor { get; init; }
        private Contrasenia() { }
        public Contrasenia(string valor)
        {
            Valor = valor;
            Validar();

        }

        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor)) throw new DatosInvalidosException("La contrasenia no puede estar vacia.");
        }

        public override bool Equals(object? obj)
        {
            Contrasenia otra = obj as Contrasenia;
            if (otra == null) return false;
            return otra.Valor == Valor;
        }

    }
}
