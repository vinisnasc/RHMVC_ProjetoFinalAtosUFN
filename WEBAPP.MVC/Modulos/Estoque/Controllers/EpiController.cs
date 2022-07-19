using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.MVC.Modulos.Estoque.Models.InputModels;
using WEBAPP.MVC.Modulos.Estoque.Services.Interfaces;

namespace WEBAPP.MVC.Modulos.Estoque.Controllers
{
    [Area("Estoque")]
    [Authorize]
    public class EpiController : Controller
    {
        private readonly IEpiService _epiService;

        public EpiController(IEpiService epiService)
        {
            _epiService = epiService;
        }

        //Gerenciamento
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await _epiService.BuscarTodos(accessToken);
            return View(result);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(EpiCadastroInputModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                await _epiService.CadastrarAsync(model, accessToken);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Retiradas
        public async Task<IActionResult> IndexFuncionariosAsync()
        {
            return Ok();
        }
    }
}
