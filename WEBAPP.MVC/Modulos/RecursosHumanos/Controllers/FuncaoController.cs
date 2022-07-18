using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.MVC.Modulos.RecursosHumanos.Models;
using WEBAPP.MVC.Modulos.RecursosHumanos.Services.Interfaces;

namespace WEBAPP.MVC.Modulos.RecursosHumanos.Controllers
{
    [Authorize]
    [Area("RecursosHumanos")]
    public class FuncaoController : Controller
    {
        private readonly IFuncaoService _funcaoService;

        public FuncaoController(IFuncaoService funcaoService)
        {
            _funcaoService = funcaoService;
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await _funcaoService.BuscarTodos(accessToken);
            return View(result);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(FuncaoModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _funcaoService.CadastrarAsync(model, accessToken);
                if (response != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var funcao = await _funcaoService.BuscarPorIdAsync(id, accessToken);
            if (funcao != null)
                return View(funcao);

            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(FuncaoModel model, Guid id)
        {
            if (ModelState.IsValid)
            {
                model.Id = id;
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _funcaoService.AtualizarAsync(id, model, accessToken);
                if (response != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await _funcaoService.ListarFuncFuncaoAsync(id, accessToken);
            return View(result);
        }
    }
}
