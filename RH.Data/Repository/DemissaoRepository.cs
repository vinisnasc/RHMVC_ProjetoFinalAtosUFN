using Microsoft.EntityFrameworkCore;
using RH.Data.Contexto;
using RH.Domain.Entities;
using RH.Domain.Interfaces.Repository;

namespace RH.Data.Repository
{
    public class DemissaoRepository : BaseRepository<Demissao>, IDemissaoRepository
    {
        public DemissaoRepository(RhContext context) : base(context) { }

        public async Task<bool> ExistePagamentoDemissaoAsync(Guid id)
        {
            return await _context.Demissao.AnyAsync(x => x.Id == id);
        }

        public async Task<Demissao> BuscarDemissaoDataAsync(DateTime dataPagamento, Guid funcionarioId)
        {
            return await _context.Demissao.Include(x => x.Funcionario)
                                          .ThenInclude(x => x.ContaBancaria)
                                          .FirstOrDefaultAsync(x => x.DataPagamento == dataPagamento && x.FuncionarioId == funcionarioId);
        }
    }
}
