using DuendeIdentityServerProject.Services.RHApiService.Models;

namespace DuendeIdentityServerProject.Services.RHApiService.Interfaces
{
    public interface IFuncionarioService
    {
        Task<FuncionarioModel> FindByEmail(string email);
    }
}
