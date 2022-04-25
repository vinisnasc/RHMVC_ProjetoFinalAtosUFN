using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using WEBAPP.MVC.Models.EstoqueModels.InputModels;
using WEBAPP.MVC.Services.IServices;

namespace WEBAPP.MVC.Controllers
{
    public class UniformeController : Controller
    {
        private readonly IUniformeService _uniformeService;

        public UniformeController(IUniformeService uniformeService)
        {
            _uniformeService = uniformeService;
        }

        //Gerenciamento
        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await _uniformeService.BuscarTodos(accessToken);
            return View(result);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UniformeCadastroInputModel model)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                await _uniformeService.CadastrarAsync(model, accessToken);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
