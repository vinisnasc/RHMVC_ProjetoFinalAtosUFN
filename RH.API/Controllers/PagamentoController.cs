using Microsoft.AspNetCore.Mvc;
using RH.Domain.Interfaces.Services;

namespace RH.API.Controllers
{
    /// <summary>
    /// Controller de pagamento
    /// </summary>
    public class PagamentoController : BaseController
    {
        private readonly IPagamentosService _pagamentosService;
        private readonly IFuncionarioService _funcionarioService;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="pagamentosService"></param>
        /// <param name="funcionarioService"></param>
        /// <param name="notificador"></param>
        public PagamentoController(IPagamentosService pagamentosService, IFuncionarioService funcionarioService, INotificador notificador) : base(notificador)
        {
            _pagamentosService = pagamentosService;
            _funcionarioService = funcionarioService;
        }

        [HttpPost]
        public async Task<ActionResult> GerarFolhaDePagamento(DateTime dataPagamento)
        {
           await _pagamentosService.GerarFolhaPagamentoAsync(dataPagamento);
            return Ok("Folha gerada com sucesso!");
        }

        [HttpPost("DecimoTerceiro")]
        public async Task<ActionResult> GerarDecimoTerceiro(DateTime dataPagamento)
        {
            await _pagamentosService.GerarDecimoTerceiroAsync(dataPagamento);
            return Ok("Decimo gerado com sucesso!");
        }

        [HttpPost("Ferias")]
        public async Task<ActionResult> GerarFerias(Guid id, DateTime dataPagamento)
        {
            await _pagamentosService.GerarFeriasAsync(dataPagamento, id);
            return Ok("Ferias gerada com sucesso!");
        }
    }
}
