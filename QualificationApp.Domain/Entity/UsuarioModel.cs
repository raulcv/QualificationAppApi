using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QualificationApp.Domain.Entity
{
    public class UsuarioModel : BaseTransactionEntity
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        public string Imagen { get; set; }
        [Required(ErrorMessage = "El nombre de usuario no puede estar vacío.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El Email no puede estar vacío.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "La contraseña no debe estar vacía.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public string Estado { get; set; }

    }
}
