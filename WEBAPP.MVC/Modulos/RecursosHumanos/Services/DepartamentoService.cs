using System.Net.Http.Headers;
using WEBAPP.MVC.Modulos.RecursosHumanos.Models;
using WEBAPP.MVC.Modulos.RecursosHumanos.Services.Interfaces;
using WEBAPP.MVC.Utils;

namespace WEBAPP.MVC.Modulos.RecursosHumanos.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Departamento";

        public DepartamentoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<DepartamentoModel>> BuscarTodos(string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<DepartamentoModel>>();
        }

        public async Task<DepartamentoModel> CadastrarAsync(DepartamentoModel dto, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.PostAsJson(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<DepartamentoModel>();

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<DepartamentoModel> BuscarPorIdAsync(Guid id, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<DepartamentoModel>();
        }

        public async Task<DepartamentoModel> AtualizarAsync(Guid id, DepartamentoModel dto, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.PutAsJson(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<DepartamentoModel>();

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<IEnumerable<FuncionarioDeptoModel>> ListarFuncDeptoAsync(Guid id, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            string path = BasePath + "/Funcionarios/" + id;
            var response = await _client.GetAsync(path);
            return await response.ReadContentAs<List<FuncionarioDeptoModel>>();
        }
    }
}