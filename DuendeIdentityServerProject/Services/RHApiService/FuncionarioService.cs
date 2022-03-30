using DuendeIdentityServerProject.Services.RHApiService.Interfaces;
using DuendeIdentityServerProject.Services.RHApiService.Models;
using DuendeIdentityServerProject.Services.RHApiService.Utils;
using System.Net.Http.Headers;

namespace DuendeIdentityServerProject.Services.RHApiService
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Funcionario";

        public FuncionarioService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<FuncionarioModel> FindByEmail(string email)
        {
            var response = await _client.GetAsync($"{BasePath}/Email/{email}");
            return await response.ReadContentAs<FuncionarioModel>();
        }
    }
}
