using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmoxarifadoController : ControllerBase
    {
        private readonly IAlmoxarifadoService _almoxarifadoService;

        public AlmoxarifadoController(IAlmoxarifadoService almoxarifadoService)
        {
            _almoxarifadoService = almoxarifadoService ?? throw new ArgumentNullException(nameof(almoxarifadoService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlmoxarifadoDto>>> FindAllAsync()
        {
            var produtos = await _almoxarifadoService.BuscarTodos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlmoxarifadoDto>> FindByIdAsync(Guid id)
        {
            var produto = await _almoxarifadoService.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(AlmoxarifadoCadastroDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = await _almoxarifadoService.Cadastrar(dto);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> AlterarProdutoAsync(AlmoxarifadoUpdateDto dto)
        {
            if (dto == null)
                return BadRequest();

            var result = await _almoxarifadoService.Alterar(dto);
            return Ok(result);
        }
    }
}
