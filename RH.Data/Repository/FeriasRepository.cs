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
    public class FeriasRepository : BaseRepository<Ferias>, IFeriasRepository
    {
        public FeriasRepository(RhContext context) : base(context)
        {}

        public async Task<int> VerificarQuantidadeFeriasRecebidasAsync(Guid idFunc)
        {
            return await _context.Ferias.CountAsync(x => x.FuncionarioId == idFunc);
        }

        public async Task<Ferias> BuscarFeriasData(DateTime dataPagamento, Guid id)
        {
            return await _context.Ferias.Include(x => x.Funcionario).ThenInclude(x => x.ContaBancaria)
                                              .FirstOrDefaultAsync(x => x.DataPagamento == dataPagamento && x.FuncionarioId == id);
        }

        public async Task<Ferias> BuscarFeriasMesAsync(DateTime data, Guid funcionarioid)
        {
            return await _context.Ferias.FirstOrDefaultAsync(x => x.FuncionarioId == funcionarioid && x.DataPagamento.Month == data.Month && x.DataPagamento.Year == data.Year);
        }
    }
}
