using Estoque.Domain.Dto;

namespace Estoque.Domain.Interfaces.Services
{
    public interface IUniformeService
    {
        Task<List<UniformeDto>> BuscarTodos();
        Task<UniformeDto> Cadastrar(UniformeCadastroDto dto);
    }
}
