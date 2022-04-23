using QualificationApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Base
{
    public class ExceptionLog
    {
        public int Host { get; set; }
        public string Uri { get; set; }
        public string Mensaje { get; set; }
        public string Usuaio { get; set; }
    }
}
