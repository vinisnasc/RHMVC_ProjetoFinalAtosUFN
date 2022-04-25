using WEBAPP.MVC.Models.EstoqueModels;
using WEBAPP.MVC.Models.EstoqueModels.InputModels;

namespace WEBAPP.MVC.Services.IServices
{
    public interface IAlmoxarifadoService
    {
        Task<List<AlmoxarifadoViewModel>> BuscarTodos(string accessToken);
        Task CadastrarAsync(AlmoxarifadoCadastroInputModel dto, string accessToken);
        Task Update(AlmoxarifadoCadastroInputModel model, string accessToken);
        Task<AlmoxarifadoViewModel> FindById(Guid id, string accessToken);
    }
}
