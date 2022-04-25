using Estoque.Domain.Dto;

namespace Estoque.Domain.Interfaces.Services
{
    public interface IEpiService
    {
        Task<List<EpiDto>> BuscarTodos();
        Task<EpiDto> Cadastrar(EpiCadastrarDto dto);
    }
}
