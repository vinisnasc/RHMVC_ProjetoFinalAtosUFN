using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RH.Domain.Dtos.Input;
using RH.Domain.Interfaces.Services;
using System.Net;

namespace RH.MVC.Controllers
{
    [Authorize]
    public class DepartamentosController : Controller
    {
        private readonly IDepartamentoService _departamentoService;

        public DepartamentosController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return View(await _departamentoService.BuscarTodos());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(DepartamentoCadastroDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _departamentoService.CadastrarAsync(dto);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("NomeDepartamento", ex.Message);
                    return View(dto);
                }
            }
            return View(dto);
        }

       public async Task<IActionResult> Editar(Guid id)
       {
            if (id == Guid.Empty)
                return NotFound();

            var departamento = await _departamentoService.BuscarPorIdAsync(id);

            if (departamento == null)
                return NotFound();

            return View(departamento);
       }

        [HttpPost]
        public async Task<IActionResult> Editar(Guid id, DepartamentoEditarDto dto)
        {
            var depto = await _departamentoService.BuscarPorIdAsync(id);
            if (ModelState.IsValid)
            {
                try
                {
                    await _departamentoService.AtualizarAsync(id, dto);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("NomeDepartamento", ex.Message);
                    return View(depto);
                }
            }
            return View(depto);
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            if(ModelState.IsValid)
            {
                var list = await _departamentoService.ListarFuncDeptoAsync(id);
                
                    return View(list);

            }
            return BadRequest(ModelState);
        }
    }
}
