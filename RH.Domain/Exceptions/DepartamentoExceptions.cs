using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Exceptions
{
    public class DepartamentoJaExisteException : Exception
    {
        public DepartamentoJaExisteException() : base("Este departamento já existe!")
        { }
    }
}
