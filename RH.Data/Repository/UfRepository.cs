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
    public class UfRepository : BaseRepository<Uf>, IUfRepository
    {
        public UfRepository(RhContext contexto) : base(contexto)
        {}

        public async Task<Guid> BuscarIdPorUfAsync(string uf)
        {
            var entidade = await _context.Uf.FirstOrDefaultAsync(x => x.Sigla == uf);
            return entidade.Id;
        }
    }
}
