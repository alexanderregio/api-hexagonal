using System;
using System.ComponentModel.DataAnnotations;

namespace Hexagonal.Domain.Models
{
    public class Usuario
    {
        /// <summary>
        /// Identificador do usuário
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public Guid? Id { get; set; }

        /// <summary>
        /// Login do usuário
        /// </summary>
        [Required(
            AllowEmptyStrings = false, 
            ErrorMessage = "Login requerido!")]
        public string Login { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "Senha requerida!")]
        public string Senha { get; set; }
    }
}