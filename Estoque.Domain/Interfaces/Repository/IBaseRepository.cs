using Estoque.Domain.Entities;

namespace Estoque.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Incluir(T entity);
        Task Alterar(T entity);
        T SelecionarPorId(Guid id);
        List<T> SelecionarTudo();
    }
}
