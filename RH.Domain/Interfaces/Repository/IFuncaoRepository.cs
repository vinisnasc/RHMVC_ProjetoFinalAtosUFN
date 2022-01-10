using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IFuncaoRepository : IBaseRepository<Funcao>
    {
        Task<int> QuantidadeFuncionarioAsync(Guid id);
        Task<bool> ExisteFuncaoAsync(string nome);
        IEnumerable<Funcionario> BuscarFuncFuncao(Guid id);
    }
}
