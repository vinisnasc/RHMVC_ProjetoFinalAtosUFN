using Estoque.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        Task<FuncionarioDto> CadastrarFuncionario(FuncionarioDto dto);
        Task<List<FuncionarioDto>> BuscarTodos();
        Task<FuncionarioDto> FindById(Guid id);
    }
}
