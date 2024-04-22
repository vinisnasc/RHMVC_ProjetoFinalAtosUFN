using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using RH.Domain.Interfaces.Services;
using RH.Domain.Interfaces.Services.RabbitMQ;

namespace RH.API.Controllers
{
    /// <summary>
    /// Controller de funcionarios
    /// </summary>
    public class FuncionarioController : BaseController
    {
        private readonly IFuncionarioService _funcionarioService;
        private IRabbitMQSender _rabbitMQSender;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="funcionarioService"></param>
        /// <param name="rabbitMQSender"></param>
        /// <param name="notificador"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FuncionarioController(IFuncionarioService funcionarioService, IRabbitMQSender rabbitMQSender, INotificador notificador) : base (notificador)
        {
            _funcionarioService = funcionarioService ?? throw new ArgumentNullException(nameof(funcionarioService));
            _rabbitMQSender = rabbitMQSender ?? throw new ArgumentNullException(nameof(rabbitMQSender));
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

        [AllowAnonymous]
        [HttpGet("Email/{email}")]
        public async Task<ActionResult<FuncionarioViewDtoResult>> FindByEmail(string email)
        {
            var funcionario = await _funcionarioService.ProcurarPorEmailAsync(email);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult> Create(FuncionarioCadastroDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = await _funcionarioService.CadastrarFuncionarioAsync(dto);
            _rabbitMQSender.SendMessage(result);
            return Ok(result);
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
