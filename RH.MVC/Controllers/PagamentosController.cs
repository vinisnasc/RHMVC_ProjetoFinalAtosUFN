using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RH.Domain.Dtos.Input;
using RH.Domain.Interfaces.Services;

namespace RH.MVC.Controllers
{
    [Authorize]
    public class PagamentosController : Controller
    {
        private readonly IPagamentosService _pagamentosService;
        private readonly IFuncionarioService _funcionarioService;

        public PagamentosController(IPagamentosService pagamentosService, IFuncionarioService funcionarioService)
        {
            _pagamentosService = pagamentosService;
            _funcionarioService = funcionarioService;
        }

        public async Task<IActionResult> Index()
        {
            var funcionarios = await _funcionarioService.BuscarTodosAtivosAsync();
            ViewBag.Funcionarios = new SelectList(funcionarios, "Id", "Nome");
            return View();
        }

        public async Task<IActionResult> GerarFolhaPagamento(PagamentosDto pagamento)
        {
            await _pagamentosService.GerarFolhaPagamentoAsync(pagamento.DataPagamento);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GerarDecimoTerceiro(PagamentosDto pagamento)
        {
            await _pagamentosService.GerarDecimoTerceiroAsync(pagamento.DataPagamento);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> GerarFerias(PagamentosDto pagamento)
        {
            try
            {
                var funcionarios = await _funcionarioService.BuscarTodosAtivosAsync();
                ViewBag.Funcionarios = new SelectList(funcionarios, "ID", "Nome");

                await _pagamentosService.GerarFeriasAsync(pagamento.DataPagamento, pagamento.FuncionarioId);
                return RedirectToAction("Index","Pagamentos");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("IdFuncionario", ex.Message);
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
