using WEBAPP.MVC.Models.EstoqueModels;
using WEBAPP.MVC.Models.EstoqueModels.InputModels;

namespace WEBAPP.MVC.Services.IServices
{
    public interface IEpiService
    {
        Task<List<EpiViewModel>> BuscarTodos(string accessToken);
        Task CadastrarAsync(EpiCadastroInputModel model, string accessToken);
    }
}
