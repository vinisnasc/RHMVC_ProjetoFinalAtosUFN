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
    public class MunicipioRepository : BaseRepository<Municipio>, IMunicipioRepository
    {
        private readonly RhContext _context;
        public MunicipioRepository(RhContext contexto) : base(contexto)
        {
            _context = contexto;
        }

        public async Task<Municipio> BuscarPorNomeUfAsync(string nome, Guid ufId)
        {
            return await _context.Municipio.FirstOrDefaultAsync(x => x.NomeMunicipio == nome && x.UfId == ufId);
        }
    }
}
