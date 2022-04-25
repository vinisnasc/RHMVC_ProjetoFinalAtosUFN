using Estoque.Domain.Entities;

namespace Estoque.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Incluir(T entity);
        Task<T> Alterar(T entity);
        Task<T> SelecionarPorId(Guid id);
        Task<List<T>> SelecionarTudo();
    }
}
