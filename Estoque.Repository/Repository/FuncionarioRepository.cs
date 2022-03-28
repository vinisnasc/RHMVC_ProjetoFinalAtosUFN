using Estoque.Domain;
using Estoque.Domain.Interfaces.Repository;

namespace Estoque.Data.Repository
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public override string TableName { get; set; } = "Funcionarios";
    }
}
