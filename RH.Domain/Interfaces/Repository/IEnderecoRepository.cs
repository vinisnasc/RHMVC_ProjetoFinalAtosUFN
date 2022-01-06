using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        Task<Endereco> ProcurarEndereco(string cep, int num, string compl);
    }
}
