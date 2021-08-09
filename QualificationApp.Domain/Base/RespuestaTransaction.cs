using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Base
{
    public class RespuestaTransaction<TEntity> where TEntity : class
    {

        public int Resultado { get; set; }
        public string Mensaje { get; set; }      
        public int StatusCode { get; set; }
        public string Retorno1 { get; set; }
        public string Retorno2 { get; set; }
        public string Retorno3 { get; set; }
        public string Retorno4 { get; set; }
        public string Retorno5 { get; set; }
        public List<TEntity> Data { get; set; } = new List<TEntity>();
    }
}
