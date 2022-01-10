using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Services
{
    public interface IFuncaoService
    {
        Task<List<FuncaoViewDtoResult>> BuscarTodos();
        Task CadastrarAsync(FuncaoCadastroDto dto);
        Task<FuncaoViewDtoResult> BuscarPorIdAsync(Guid id);
        Task AtualizarAsync(Guid id, FuncaoEditarDto dto);
        Task AumentarSalarioAsync(Guid id, FuncaoEditarSalarioDto dto);
        Task<IEnumerable<FuncionarioFuncaoView>> ListarFuncFuncaoAsync(Guid id);
        Task RealizarAumentoAsync(FuncaoAumentoSalarialDto dto);
    }
}
