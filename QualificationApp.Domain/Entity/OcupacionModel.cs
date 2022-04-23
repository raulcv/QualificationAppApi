using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QualificationApp.Domain.Entity
{
    public class OcupacionModel : BaseTransactionEntity
    {
        public int IdOcupacion { get; set; }

        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
