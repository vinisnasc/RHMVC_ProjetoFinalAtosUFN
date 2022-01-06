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
    public class FuncaoRepository : BaseRepository<Funcao>, IFuncaoRepository
    {
        public FuncaoRepository(RhContext context) : base(context)
        {
        }

        public async Task<int> QuantidadeFuncionarioAsync(Guid id)
        {
            return await _context.Funcionario.CountAsync(x => x.FuncaoId == id);
        }

        public async Task<bool> ExisteFuncao(string nome)
        {
            return await _context.Funcao.AnyAsync(x => x.NomeFuncao == nome);
        }
    }
}
