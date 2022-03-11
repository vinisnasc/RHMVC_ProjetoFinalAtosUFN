using Microsoft.AspNetCore.Mvc;
using WEBAPP.MVC.Models;
using WEBAPP.MVC.Models.InputModel;

namespace WEBAPP.MVC.Services.IServices
{
    public interface IFuncionarioService
    {
        Task<List<FuncionarioModel>> BuscarTodosAtivos(string accessToken);
        Task<FuncionarioModel> FindById(Guid id, string accessToken);
        Task Create(FuncionarioCadastro dto, string accessToken);
        Task Update(FuncionarioUpdate model, string accessToken);
    }
}
