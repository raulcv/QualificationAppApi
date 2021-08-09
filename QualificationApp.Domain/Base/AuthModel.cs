using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QualificationApp.Domain.Base
{
    public class AuthModel
    {
        [Required(ErrorMessage ="Usuario es obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Clave es obligatorio")]

        public string Password { get; set; }
    }
}
