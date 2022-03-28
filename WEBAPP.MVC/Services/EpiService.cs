using System.Net.Http.Headers;
using WEBAPP.MVC.Models.EstoqueModels;
using WEBAPP.MVC.Models.EstoqueModels.InputModels;
using WEBAPP.MVC.Services.IServices;
using WEBAPP.MVC.Utils;

namespace WEBAPP.MVC.Services
{
    public class EpiService : IEpiService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Epi";

        public EpiService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<List<EpiViewModel>> BuscarTodos(string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<EpiViewModel>>();
        }

        public async Task CadastrarAsync(EpiCadastroInputModel dto, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _client.PostAsJson(BasePath, dto);
            if (response.IsSuccessStatusCode)
                return;

            else
                throw new Exception("Something went wrong when calling API");
        }
    }
}
