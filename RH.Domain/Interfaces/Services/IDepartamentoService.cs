using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;

namespace RH.Domain.Interfaces.Services
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoViewDtoResult>> BuscarTodos();
        Task<DepartamentoViewDtoResult> CadastrarAsync(DepartamentoCadastroDto dto);
        Task<DepartamentoViewDtoResult> BuscarPorIdAsync(Guid id);
        Task<DepartamentoViewDtoResult> AtualizarAsync(DepartamentoEditarDto dto);
        Task<IEnumerable<FuncionarioDepartamentoView>> ListarFuncDeptoAsync(Guid id);
    }
}
