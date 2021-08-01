using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Base
{
    public class RespuestaTransaction<T> where T : class
    {
        public int Resultado { get; set; }
        public string Mensaje { get; set; }
        public string Retorno1 { get; set; }
        public string Retorno2 { get; set; }
        public string Retorno3 { get; set; }
        public string Retorno4 { get; set; }
        public string Retorno5 { get; set; }
        public IEnumerable<T> data { get; set; }
    }
}
