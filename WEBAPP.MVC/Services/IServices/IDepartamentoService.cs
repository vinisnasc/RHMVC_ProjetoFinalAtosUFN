using WEBAPP.MVC.Models;

namespace WEBAPP.MVC.Services.IServices
{
    public interface IDepartamentoService
    {
        Task<IEnumerable<DepartamentoModel>> BuscarTodos(string accessToken);
        Task<DepartamentoModel> CadastrarAsync(DepartamentoModel dto, string accessToken);
        Task<DepartamentoModel> BuscarPorIdAsync(Guid id, string accessToken);
        Task<DepartamentoModel> AtualizarAsync(Guid id, DepartamentoModel dto, string accessToken);
        Task<IEnumerable<FuncionarioDeptoModel>> ListarFuncDeptoAsync(Guid id, string accessToken);
    }
}
