using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IContaBancariaRepository : IBaseRepository<ContaBancaria>
    {
        Task<ContaBancaria> BuscarContaAsync(int numBanco, string agencia, string conta);
    }
}
