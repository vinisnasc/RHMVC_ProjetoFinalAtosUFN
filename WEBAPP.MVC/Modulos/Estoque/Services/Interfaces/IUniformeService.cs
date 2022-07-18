using WEBAPP.MVC.Models.EstoqueModels;
using WEBAPP.MVC.Models.EstoqueModels.InputModels;

namespace WEBAPP.MVC.Services.IServices
{
    public interface IUniformeService
    {
        Task<List<UniformeViewModel>> BuscarTodos(string accessToken);
        Task CadastrarAsync(UniformeCadastroInputModel dto, string accessToken);
    }
}
