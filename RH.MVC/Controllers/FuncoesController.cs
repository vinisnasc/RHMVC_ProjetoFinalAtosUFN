using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Interfaces.Services;
using System.Net;

namespace RH.MVC.Controllers
{
    public class FuncoesController : Controller
    {
        private readonly IFuncaoService _funcaoService;

        public FuncoesController(IFuncaoService funcaoService)
        {
            _funcaoService = funcaoService;
        }

        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return View(await _funcaoService.BuscarTodos());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(FuncaoCadastroDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _funcaoService.CadastrarAsync(dto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("NomeFuncao", ex.Message);
                    return View(dto);
                }
            }
            return View(dto);
        }

    }
}
