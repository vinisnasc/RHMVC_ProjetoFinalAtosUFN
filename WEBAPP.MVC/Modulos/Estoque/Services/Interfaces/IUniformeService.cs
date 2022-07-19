using WEBAPP.MVC.Modulos.Estoque.Models;
using WEBAPP.MVC.Modulos.Estoque.Models.InputModels;

namespace WEBAPP.MVC.Modulos.Estoque.Services.Interfaces
{
    public interface IUniformeService
    {
        Task<List<UniformeViewModel>> BuscarTodos(string accessToken);
        Task CadastrarAsync(UniformeCadastroInputModel dto, string accessToken);
    }
}