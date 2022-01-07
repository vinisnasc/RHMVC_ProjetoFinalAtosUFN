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

    public class FuncionarioJaEstaDemitidoException : Exception
    {
        public FuncionarioJaEstaDemitidoException() : base("Funcionário já está demitido!")
        { }
    }

    public class DemissaoException : Exception
    {
        public DemissaoException() : base("A data de demissao não pode ser antes da data de admissao!")
        { }
    }
}
