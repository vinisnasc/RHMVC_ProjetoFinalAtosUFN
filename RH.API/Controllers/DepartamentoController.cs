using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using RH.Domain.Interfaces.Services;

namespace RH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoViewDtoResult>>> FindAll()
        {
            var departamentos = await _departamentoService.BuscarTodos();
            return Ok(departamentos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoViewDtoResult>> FindById(Guid id)
        {
            var departamento = await _departamentoService.BuscarPorIdAsync(id);
            return Ok(departamento);
        }

        [HttpGet("Funcionarios/{id}")]
        public async Task<ActionResult<IEnumerable<FuncionarioDepartamentoView>>> ListarFuncionariosDoDepartamento(Guid id)
        {
            var funcionarios = await _departamentoService.ListarFuncDeptoAsync(id);
            return Ok(funcionarios);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DepartamentoCadastroDto dto)
        {
            if (dto == null)
                return BadRequest();

            await _departamentoService.CadastrarAsync(dto);
            return Ok("Depto cadastrado com sucesso");
        }

        [HttpPut]
        public async Task<ActionResult> Update(Guid id, DepartamentoEditarDto dto)
        {
            if (dto == null)
                return BadRequest();

            await _departamentoService.AtualizarAsync(id, dto);
            return Ok("Depto atualizado com sucesso");
        }
    }
}
