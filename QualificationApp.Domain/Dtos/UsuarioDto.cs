using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Dtos
{
    public class UsuarioDto: BaseEntity
    {
        public int IdUsuario { get; set; }        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Imagen { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Estado { get; set; }
    }


}
