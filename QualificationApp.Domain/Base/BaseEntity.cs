using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Base
{

    public class BaseEntity
    {
        public string UsuarioCreacion { get; set; }
        public string FechaCreacion { get; set; }
        public string FechaEdicion { get; set; }
        public string UsuarioEdicion { get; set; }
    }

    public class BaseTransactionEntity
    {
        public string Usuario { get; set; }
    }
}
