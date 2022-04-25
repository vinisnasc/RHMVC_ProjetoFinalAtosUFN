using Estoque.Domain;
using Estoque.Domain.Interfaces.Repository;

namespace Estoque.Data.Repository
{
    public class UniformeRepository : BaseRepository<Uniforme>, IUniformeRepository
    {
        public override string TableName { get; set; } = "Uniformes";
    }
}