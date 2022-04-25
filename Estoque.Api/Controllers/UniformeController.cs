using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniformeController : ControllerBase
    {
        private readonly IUniformeService _uniformeService;

        public UniformeController(IUniformeService uniformeService)
        {
            _uniformeService = uniformeService ?? throw new ArgumentNullException(nameof(uniformeService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UniformeDto>>> FindAllAsync()
        {
            var uniformes = await _uniformeService.BuscarTodos();
            return Ok(uniformes);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(UniformeCadastroDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = await _uniformeService.Cadastrar(dto);
            return Ok(result);
        }
    }
}
