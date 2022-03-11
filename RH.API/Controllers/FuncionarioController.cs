using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using RH.Domain.Interfaces.Services;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioViewDtoResult>>> BuscarTodosAtivos()
        {
            var funcionarios = await _funcionarioService.BuscarTodosAtivosAsync();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioViewDtoResult>> FindById(Guid id)
        {
            var funcionario = await _funcionarioService.BuscarPorId(id);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FuncionarioCadastroDto dto)
        {
            if (dto == null)
                return BadRequest();

            await _funcionarioService.CadastrarFuncionarioAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditarDadosPessoais(Guid id, FuncionarioEditarDadosPessoaisDto dto)
        {
            await _funcionarioService.EditarDadosPessoaisAsync(id, dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Demitir(Guid id, DateTime demissao)
        {
            await _funcionarioService.Demitir(id, demissao);
            return Ok("Funcionario demitido");
        }
    }
}
