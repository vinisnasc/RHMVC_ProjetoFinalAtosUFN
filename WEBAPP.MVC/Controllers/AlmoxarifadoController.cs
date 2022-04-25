using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.MVC.Models.EstoqueModels.InputModels;
using WEBAPP.MVC.Services.IServices;

namespace WEBAPP.MVC.Controllers
{
    public class AlmoxarifadoController : Controller
    {
        private readonly IAlmoxarifadoService _almoxarifadoService;

        public AlmoxarifadoController(IAlmoxarifadoService almoxarifadoService)
        {
            _almoxarifadoService = almoxarifadoService;
        }

        //Gerenciamento
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await _almoxarifadoService.BuscarTodos(accessToken);
            return View(result);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(AlmoxarifadoCadastroInputModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                await _almoxarifadoService.CadastrarAsync(model, accessToken);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            return View(await _almoxarifadoService.FindById(id, accessToken));
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(AlmoxarifadoCadastroInputModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");

                await _almoxarifadoService.Update(model, accessToken);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
