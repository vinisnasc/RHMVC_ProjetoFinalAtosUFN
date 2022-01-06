using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Services
{
    public interface IDepartamentoService
    {
        Task<List<DepartamentoViewDtoResult>> BuscarTodos();
        Task CadastrarAsync(DepartamentoCadastroDto dto);
        Task<DepartamentoViewDtoResult> BuscarPorIdAsync(Guid id);
        Task AtualizarAsync(Guid id, DepartamentoEditarDto dto);
        Task<IEnumerable<FuncionarioDepartamentoView>> ListarFuncDeptoAsync(Guid id);
    }
}
