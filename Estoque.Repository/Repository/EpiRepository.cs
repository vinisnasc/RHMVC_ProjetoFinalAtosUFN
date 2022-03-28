using Estoque.Domain;
using Estoque.Domain.Interfaces.Repository;

namespace Estoque.Data.Repository
{
    public class EpiRepository : BaseRepository<Epi>, IEpiRepository
    {
        public override string TableName { get; set; } = "Epis";
    }
}
