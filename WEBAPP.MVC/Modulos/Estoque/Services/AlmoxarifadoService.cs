using System.Net.Http.Headers;
using WEBAPP.MVC.Models.EstoqueModels;
using WEBAPP.MVC.Models.EstoqueModels.InputModels;
using WEBAPP.MVC.Services.IServices;
using WEBAPP.MVC.Utils;

namespace WEBAPP.MVC.Services
{
    public class AlmoxarifadoService : IAlmoxarifadoService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Almoxarifado";

        public AlmoxarifadoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<AlmoxarifadoViewModel> FindById(Guid id, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<AlmoxarifadoViewModel>();
        }

        public async Task<List<AlmoxarifadoViewModel>> BuscarTodos(string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<AlmoxarifadoViewModel>>();
        }

        public async Task CadastrarAsync(AlmoxarifadoCadastroInputModel dto, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.PostAsJson(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return;

            else
                throw new Exception("Something went wrong when calling API");
        }

        public async Task Update(AlmoxarifadoCadastroInputModel model, string accessToken)
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
