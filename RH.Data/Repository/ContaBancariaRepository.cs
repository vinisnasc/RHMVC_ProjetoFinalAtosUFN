using Microsoft.EntityFrameworkCore;
using RH.Data.Contexto;
using RH.Domain.Entities;
using RH.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Data.Repository
{
    public class ContaBancariaRepository : BaseRepository<ContaBancaria>, IContaBancariaRepository
    {
        public ContaBancariaRepository(RhContext context) : base(context)
        {
        }

        public async Task<ContaBancaria> BuscarContaAsync(int numBanco, string agencia, string conta)
        {
            return await _context.ContaBancaria.FirstOrDefaultAsync(x => x.Banco == numBanco && x.Agencia == agencia && x.ContaCorrente == conta);
        }
    }
}
