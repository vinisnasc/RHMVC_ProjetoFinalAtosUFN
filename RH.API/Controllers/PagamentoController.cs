using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Interfaces.Services;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentosService _pagamentosService;
        private readonly IFuncionarioService _funcionarioService;

        public PagamentoController(IPagamentosService pagamentosService, IFuncionarioService funcionarioService)
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
