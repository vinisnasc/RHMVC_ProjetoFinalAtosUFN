using WEBAPP.MVC.Modulos.RecursosHumanos.Models;

namespace WEBAPP.MVC.Modulos.RecursosHumanos.Services.Interfaces
{
    public interface IFuncaoService
    {
        Task<List<FuncaoModel>> BuscarTodos(string accessToken);
        Task<FuncaoModel> CadastrarAsync(FuncaoModel dto, string accessToken);
        Task<FuncaoModel> BuscarPorIdAsync(Guid id, string accessToken);
        Task<FuncaoModel> AtualizarAsync(Guid id, FuncaoModel dto, string accessToken);
        Task AumentarSalarioAsync(Guid id, FuncaoModel dto, string accessToken);
        Task<IEnumerable<FuncionarioFuncaoModel>> ListarFuncFuncaoAsync(Guid id, string accessToken);
        Task RealizarAumentoAsync(FuncaoModel dto, string accessToken);
    }
}