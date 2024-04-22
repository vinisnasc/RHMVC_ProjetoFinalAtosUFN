using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using RH.Domain.Interfaces.Services;

namespace RH.API.Controllers
{
    /// <summary>
    /// Controller de departamentos
    /// </summary>
    public class DepartamentoController : BaseController
    {
        private readonly IDepartamentoService _departamentoService;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="departamentoService"></param>
        /// <param name="notificador"></param>
        public DepartamentoController(IDepartamentoService departamentoService, INotificador notificador)
                                            : base(notificador) => _departamentoService = departamentoService;

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

        /// <summary>
        /// Retorna os dados de um departamento a partir do id informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartamentoViewDtoResult>> FindById(Guid id)
        {
            var departamento = await _departamentoService.BuscarPorIdAsync(id);
            return Ok(departamento);
        }

        /// <summary>
        /// Retorna os funcionarios de um departamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("Funcionarios/{id}")]
        public async Task<ActionResult<IEnumerable<FuncionarioDepartamentoView>>> ListarFuncionariosDoDepartamento(Guid id)
        {
            var funcionarios = await _departamentoService.ListarFuncDeptoAsync(id);
            return Ok(funcionarios);
        }

        /// <summary>
        /// Cadastra um novo departamento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(DepartamentoCadastroDto dto)
        {
            if (dto == null) return BadRequest();

            var result = await _departamentoService.CadastrarAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Atualiza os dados de um departamento
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> Update(DepartamentoEditarDto dto)
        {
            if (dto == null) return BadRequest();

            var result = await _departamentoService.AtualizarAsync(dto);
            return Ok(result);
        }
    }
}
