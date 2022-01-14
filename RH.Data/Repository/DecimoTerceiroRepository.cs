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
    public class DecimoTerceiroRepository : BaseRepository<DecimoTerceiro>, IDecimoTerceiroRepository
    {
        public DecimoTerceiroRepository(RhContext context) : base(context)
        {}

        public async Task<DecimoTerceiro> BuscaPrimeiraParcelaAsync(Guid funcionarioid, int ano)
        {
            return await _context.DecimoTerceiro.FirstOrDefaultAsync(x => x.FuncionarioId == funcionarioid && x.DataPagamento.Year == ano);
        }

        public async Task<List<DecimoTerceiro>> BuscaTodasParcelasAnoAsync(Guid funcionarioid, int ano)
        {
            return await _context.DecimoTerceiro.Where(x => x.FuncionarioId == funcionarioid && x.DataPagamento.Year == ano).ToListAsync();
        }

        public async Task<List<DecimoTerceiro>> PegarTodosDecimosDataAsync(DateTime dataPagamento)
        {
            if(dataPagamento.Month != 12)
            return await _context.DecimoTerceiro.Where(x => x.DataPagamento.Year == dataPagamento.Year &&
                                                       x.DataPagamento.Month != 12)
                                           .Include(x => x.Funcionario)
                                           .ThenInclude(x => x.ContaBancaria).ToListAsync();

            else
                return await _context.DecimoTerceiro.Where(x => x.DataPagamento.Year == dataPagamento.Year &&
                                                       x.DataPagamento.Month == 12)
                                           .Include(x => x.Funcionario)
                                           .ThenInclude(x => x.ContaBancaria).ToListAsync();
        }
    }
}
