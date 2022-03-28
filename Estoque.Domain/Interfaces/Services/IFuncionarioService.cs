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
        FuncionarioDto CadastrarFuncionario(FuncionarioDto dto);
        List<FuncionarioDto> BuscarTodos();
        FuncionarioDto FindById(Guid id);
    }
}
