using LogiaNegocio.ExcepcionesPropias;
using LogiaNegocio.ValueObjects.ArticuloVOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiaNegocio.ValueObjects.UsuarioVOs
{
    public class EmailUsuario
    {
        [MaxLength(100)]
        [EmailAddress]
        public string Valor { get; init; }
        private EmailUsuario(){}
        public EmailUsuario(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (string.IsNullOrEmpty(Valor)) throw new DatosInvalidosException("El email no puede estar vacio.");
            if (Valor.Length < 3) throw new DatosInvalidosException("El email no puede tener menos de 3 caracteres.");
        }
        public override bool Equals(object? obj) 
        {
            EmailUsuario otro = obj as EmailUsuario;
            if(otro == null) return false;
            return otro.Valor == Valor;
        }
    }
}

