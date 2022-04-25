using Estoque.Domain.Dto;

namespace Estoque.Domain.Interfaces.Services
{
    public interface IAlmoxarifadoService
    {
        Task<List<AlmoxarifadoDto>> BuscarTodos();
        Task<AlmoxarifadoDto> Cadastrar(AlmoxarifadoCadastroDto dto);
        Task<AlmoxarifadoDto> Alterar(AlmoxarifadoUpdateDto dto);
        Task<AlmoxarifadoDto> BuscarPorId(Guid id);
    }
}
