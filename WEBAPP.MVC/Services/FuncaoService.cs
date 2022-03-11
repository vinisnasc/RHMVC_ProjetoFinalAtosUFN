using System.Net.Http.Headers;
using WEBAPP.MVC.Models;
using WEBAPP.MVC.Services.IServices;
using WEBAPP.MVC.Utils;

namespace WEBAPP.MVC.Services
{
    public class FuncaoService : IFuncaoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Funcao";

        public FuncaoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<FuncaoModel>> BuscarTodos(string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<FuncaoModel>>();
        }

        public async Task<FuncaoModel> CadastrarAsync(FuncaoModel dto, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.PostAsJson(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<FuncaoModel>();

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<FuncaoModel> BuscarPorIdAsync(Guid id, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<FuncaoModel>();
        }

        public async Task<FuncaoModel> AtualizarAsync(Guid id, FuncaoModel dto, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.PutAsJson(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<FuncaoModel>();

            else
                throw new Exception("Something went wrong when calling API");
        }

        public Task AumentarSalarioAsync(Guid id, FuncaoModel dto, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FuncaoModel>> ListarFuncFuncaoAsync(Guid id, string accessToken)
        {
            throw new NotImplementedException();
        }

        public Task RealizarAumentoAsync(FuncaoModel dto, string accessToken)
        {
            throw new NotImplementedException();
        }
    }
}
