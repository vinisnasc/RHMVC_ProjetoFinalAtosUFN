using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Task<Funcionario> ProcurarPorCpfAtivoAsync(string cpf);
        Task<int> AtribuirNumeroDeRegistroAsync();
        List<Funcionario> BuscarTodosAtivos();
    }
}
