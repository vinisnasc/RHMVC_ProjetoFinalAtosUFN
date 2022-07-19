using System.Net.Http.Headers;
using WEBAPP.MVC.Modulos.Estoque.Services.Interfaces;
using WEBAPP.MVC.Modulos.RecursosHumanos.Models;
using WEBAPP.MVC.Modulos.RecursosHumanos.Models.InputModel;
using WEBAPP.MVC.Utils;

namespace WEBAPP.MVC.Modulos.Estoque.Services
{
    public class FuncionarioEstoqueService : IFuncionarioEstoqueService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Funcionario";

        public FuncionarioEstoqueService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<FuncionarioModel>> BuscarTodosAtivos(string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<FuncionarioModel>>();
        }

        public async Task<FuncionarioModel> FindById(Guid id, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<FuncionarioModel>();
        }

        public async Task Create(FuncionarioModel dto, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.PostAsJson(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return;

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task Update(FuncionarioUpdate model, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return;

            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}