using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QualificationApp.Domain.Entity
{
    public class PaisModel: BaseTransactionEntity
    {
        public int IdPais { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Abreviado { get; set; }
        [Required]
        public string Gentilicio { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
