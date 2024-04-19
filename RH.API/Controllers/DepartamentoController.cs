using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using RH.Domain.Interfaces.Services;

namespace RH.API.Controllers
{
    public class DepartamentoController : BaseController
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        /// <summary>
        /// Retorna todos os departamentos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartamentoViewDtoResult>>> FindAll()
        {
            var departamentos = await _departamentoService.BuscarTodos();
            return Ok(departamentos);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoViewDtoResult>> FindById(Guid id)
        {
            var departamento = await _departamentoService.BuscarPorIdAsync(id);
            return Ok(departamento);
        }

        [Authorize]
        [HttpGet("Funcionarios/{id}")]
        public async Task<ActionResult<IEnumerable<FuncionarioDepartamentoView>>> ListarFuncionariosDoDepartamento(Guid id)
        {
            var funcionarios = await _departamentoService.ListarFuncDeptoAsync(id);
            return Ok(funcionarios);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(DepartamentoCadastroDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = await _departamentoService.CadastrarAsync(dto);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> Update(DepartamentoEditarDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = await _departamentoService.AtualizarAsync(dto);
            return Ok(result);
        }
    }
}
