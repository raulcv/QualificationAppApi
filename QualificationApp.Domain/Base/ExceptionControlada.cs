using System;
using System.Collections.Generic;
using System.Text;

namespace QualificationApp.Domain.Base
{
    public class ExceptionControlada: Exception
    {
        public ExceptionControlada(string mensaje) : base(mensaje) { }

    }
}
