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
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FuncionarioDto>> FindAll()
        {
            var funcs = _funcionarioService.BuscarTodos();
            return Ok(funcs);
        }

        [HttpGet("{id}")]
        public ActionResult<FuncionarioDto> FindById(Guid id)
        {
            var funcionario = _funcionarioService.FindById(id);
            return Ok(funcionario);
        }

        [HttpPost]
        public ActionResult Create(FuncionarioDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = _funcionarioService.CadastrarFuncionario(dto);
            return Ok(result);
        }
    }
}
