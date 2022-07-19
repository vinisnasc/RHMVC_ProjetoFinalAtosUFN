using WEBAPP.MVC.Modulos.Estoque.Models;
using WEBAPP.MVC.Modulos.Estoque.Models.InputModels;

namespace WEBAPP.MVC.Modulos.Estoque.Services.Interfaces
{
    public interface IAlmoxarifadoService
    {
        Task<List<AlmoxarifadoViewModel>> BuscarTodos(string accessToken);
        Task CadastrarAsync(AlmoxarifadoCadastroInputModel dto, string accessToken);
        Task Update(AlmoxarifadoCadastroInputModel model, string accessToken);
        Task<AlmoxarifadoViewModel> FindById(Guid id, string accessToken);
    }
}