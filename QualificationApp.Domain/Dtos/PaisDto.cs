using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Dtos
{
    public class PaisDto: BaseEntity
    {
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public string Abreviado { get; set; }
        public string Gentilicio { get; set; }
        public string Estado { get; set; }
    }
    public class PaisRespuesta : RespuestaTransaction<PaisDto>
    {
        public List<PaisDto> paisData { get; set; } = new List<PaisDto>();
    }
}
