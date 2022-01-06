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
        Task<Funcionario> ProcurarPorCpfAtivo(string cpf);
        Task<int> AtribuirNumeroDeRegistro();
    }
}
