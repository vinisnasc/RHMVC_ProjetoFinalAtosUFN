using RH.Domain.Dtos.Input;
using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IDepartamentoRepository : IBaseRepository<Departamento>
    {
        Task<int> QuantidadeFuncionarioAsync(Guid id);
        IEnumerable<Funcionario> BuscarFuncDepto(Guid id);
        Task<bool> ExisteDepto(string depto, string subdepto);
    }
}
