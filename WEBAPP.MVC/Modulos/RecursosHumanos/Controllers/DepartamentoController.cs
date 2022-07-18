using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.MVC.Models;
using WEBAPP.MVC.Services.IServices;

namespace WEBAPP.MVC.Modulos.RecursosHumanos.Controllers
{
    [Authorize]
    [Area("RecursosHumanos")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var deptos = await _departamentoService.BuscarTodos(accessToken);
            return View(deptos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(DepartamentoModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var response = await _departamentoService.CadastrarAsync(model, accessToken);
                if (response != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var depto = await _departamentoService.BuscarPorIdAsync(id, accessToken);
            if (depto != null)
                return View(depto);

            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(DepartamentoModel model, Guid id)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                model.Id = id;
                var response = await _departamentoService.AtualizarAsync(id, model, accessToken);
                if (response != null)
                    return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await _departamentoService.ListarFuncDeptoAsync(id, accessToken);
            return View(result);
        }

        public void Imprimir(IEnumerable<FuncionarioDeptoModel> teste)
        {
            var x = teste;
        }
    }
}
