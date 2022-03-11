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
        Task<FuncaoViewDtoResult> CadastrarAsync(FuncaoCadastroDto dto);
        Task<FuncaoViewDtoResult> BuscarPorIdAsync(Guid id);
        Task<FuncaoViewDtoResult> AtualizarAsync(FuncaoEditarDto dto);
        Task AumentarSalarioAsync(Guid id, FuncaoEditarSalarioDto dto);
        Task<IEnumerable<FuncionarioFuncaoView>> ListarFuncFuncaoAsync(Guid id);
        Task RealizarAumentoAsync(FuncaoAumentoSalarialDto dto);
    }
}
