using WEBAPP.MVC.Modulos.RecursosHumanos.Models;

namespace WEBAPP.MVC.Modulos.Estoque.Services.Interfaces
{
    public interface IFuncionarioEstoqueService
    {
        Task Create(FuncionarioModel dto, string accessToken);
    }
}