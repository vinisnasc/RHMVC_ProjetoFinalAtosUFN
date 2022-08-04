using Microsoft.EntityFrameworkCore;
using RH.Data.Contexto;
using RH.Domain.Entities;
using RH.Domain.Interfaces.Repository;

namespace RH.Data.Repository
{
    public class FuncaoRepository : BaseRepository<Funcao>, IFuncaoRepository
    {
        public FuncaoRepository(RhContext context) : base(context)
        {}

        public async Task<int> QuantidadeFuncionarioAsync(Guid id)
        {
            return await _context.Funcionarios.CountAsync(x => x.FuncaoId == id && x.Ativo == true);
        }

        public async Task<bool> ExisteFuncaoAsync(string nome)
        {
            return await _context.Funcoes.AnyAsync(x => x.NomeFuncao == nome);
        }

        public IEnumerable<Funcionario> BuscarFuncFuncao(Guid id)
        {
            return _context.Funcionarios.Where(x => x.FuncaoId == id && x.Ativo == true);
        }
    }
}