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
    }
}
