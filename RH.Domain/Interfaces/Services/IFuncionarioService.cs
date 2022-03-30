using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;

namespace RH.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        Task<FuncionarioViewDtoResult> CadastrarFuncionarioAsync(FuncionarioCadastroDto dto);
        Task<FuncionarioViewDtoResult> BuscarPorId(Guid id);
        Task<List<FuncionarioViewDtoResult>> BuscarTodosAtivosAsync();
        Task Demitir(Guid id, DateTime demissao);
        Task EditarDadosPessoaisAsync(Guid id, FuncionarioEditarDadosPessoaisDto dto);
        Task<FuncionarioViewDtoResult> ProcurarPorEmailAsync(string email);
    }
}
