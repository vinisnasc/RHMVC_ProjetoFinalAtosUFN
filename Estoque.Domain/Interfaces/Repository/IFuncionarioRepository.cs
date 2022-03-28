namespace Estoque.Domain.Interfaces.Repository
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Funcionario Incluir(Funcionario entity);
        Task Alterar(Funcionario entity);
        Funcionario SelecionarPorId(Guid id);
        List<Funcionario> SelecionarTudo();
    }
}
