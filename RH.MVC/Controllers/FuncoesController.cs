using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
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

        public async Task<IActionResult> Editar(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var funcao = await _funcaoService.BuscarPorIdAsync(id);

            if (funcao == null)
                return NotFound();

            return View(funcao);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Guid id, FuncaoEditarDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _funcaoService.AtualizarAsync(id, dto);
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

        public async Task<IActionResult> AumentarSalario(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var funcao = await _funcaoService.BuscarPorIdAsync(id);

            if (funcao == null)
                return NotFound();

            return View(funcao);
        }

        [HttpPost]
        public async Task<IActionResult> AumentarSalario(Guid id, FuncaoEditarSalarioDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _funcaoService.AumentarSalarioAsync(id, dto);
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

        public async Task<IActionResult> Detalhes(Guid id)
        {
            if (ModelState.IsValid)
            {
                var list = await _funcaoService.ListarFuncFuncaoAsync(id);

                return View(list);

            }
            return BadRequest(ModelState);
        }

        public async Task<IActionResult> AumentarTodosSalarios()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AumentarTodosSalarios(FuncaoAumentoSalarialDto dto)
        {
            try
            {
                await _funcaoService.RealizarAumentoAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                if(dto.AumentoFixo != null)
                {
                    ModelState.AddModelError("AumentoFixo", ex.Message);
                    return View();
                }
                else
                {
                    ModelState.AddModelError("AumentoPercentual", ex.Message);
                    return View();
                }
            }
        }

    }
}
