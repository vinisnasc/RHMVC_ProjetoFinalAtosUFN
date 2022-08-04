using Microsoft.EntityFrameworkCore;
using RH.Data.Contexto;
using RH.Domain.Entities;
using RH.Domain.Interfaces.Repository;

namespace RH.Data.Repository
{
    public class MunicipioRepository : BaseRepository<Municipio>, IMunicipioRepository
    {
        public MunicipioRepository(RhContext contexto) : base(contexto)
        {}

        public async Task<Municipio> BuscarPorNomeUfAsync(string nome, Guid ufId)
        {
            return await _context.Municipios.FirstOrDefaultAsync(x => x.NomeMunicipio == nome && x.UfId == ufId);
        }
    }
}