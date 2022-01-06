using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Exceptions
{
    public class FuncionarioJaExisteException : Exception
    {
        public FuncionarioJaExisteException() : base("Esse funcionário está ativo no sistema!")
        { }
    }
}
