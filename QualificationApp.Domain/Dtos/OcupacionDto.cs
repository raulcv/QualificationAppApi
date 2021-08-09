using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Dtos
{
    public class OcupacionDto : BaseEntity
    {
        public int IdOcupacion { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public string TEST { get; set; }
    }
}
