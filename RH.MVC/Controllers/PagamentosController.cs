using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using RH.Domain.Interfaces.Services;

namespace RH.MVC.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly IPagamentosService _pagamentosService;

        public PagamentosController(IPagamentosService pagamentosService)
        {
            _pagamentosService = pagamentosService;
        }

        public IActionResult Index()
        {
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
                await _pagamentosService.GerarFeriasAsync(pagamento.DataPagamento, pagamento.FuncionarioId);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("FuncionarioId", ex.Message);
                return View(nameof(Index));
            }
        }
    }
}
