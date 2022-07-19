using WEBAPP.MVC.Modulos.Estoque.Models;
using WEBAPP.MVC.Modulos.Estoque.Models.InputModels;

namespace WEBAPP.MVC.Modulos.Estoque.Services.Interfaces
{
    public interface IEpiService
    {
        Task<List<EpiViewModel>> BuscarTodos(string accessToken);
        Task CadastrarAsync(EpiCadastroInputModel model, string accessToken);
    }
}