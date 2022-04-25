using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService ?? throw new ArgumentNullException(nameof(funcionarioService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDto>>> FindAllAsync()
        {
            var funcs = await _funcionarioService.BuscarTodos();
            return Ok(funcs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioDto>> FindByIdAsync(Guid id)
        {
            var funcionario = await _funcionarioService.FindById(id);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(FuncionarioDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = await _funcionarioService.CadastrarFuncionario(dto);
            return Ok(result);
        }
    }
}
