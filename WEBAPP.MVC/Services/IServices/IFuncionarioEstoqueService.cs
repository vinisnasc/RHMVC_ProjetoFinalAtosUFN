using WEBAPP.MVC.Models;

namespace WEBAPP.MVC.Services.IServices
{
    public interface IFuncionarioEstoqueService
    {
        Task Create(FuncionarioModel dto, string accessToken);
    }
}
