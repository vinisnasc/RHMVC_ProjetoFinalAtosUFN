using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RH.Domain.Dtos.Input;
using RH.Domain.Interfaces.Services;
using System.Net;

namespace RH.MVC.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IDepartamentoService _departamentoService;
        private readonly IFuncaoService _funcaoService;

        public FuncionariosController(IFuncionarioService funcionarioService, IDepartamentoService departamentoService, IFuncaoService funcaoService)
        {
            _funcionarioService = funcionarioService;
            _departamentoService = departamentoService;
            _funcaoService = funcaoService;
        }

        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return View(await _funcionarioService.BuscarTodos());
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        public async Task<IActionResult> Cadastrar()
        {
            #region ViewBags
            ViewBag.Sex = new SelectList(new object[]
            {
                new {Name = "M", Value = "Masculino"},
                new {Name = "F", Value = "Feminino"}
            }, "Value", "Name");

            var setores = await _departamentoService.BuscarTodos();
            var funcoes = await _funcaoService.BuscarTodos();

            foreach (var depto in setores)
            {
                depto.NomeDepartamento += "/" + depto.SubDepartamento;
            }

            ViewBag.Deptos = new SelectList(setores, "Id", "NomeDepartamento");
            ViewBag.Funcs = new SelectList(funcoes, "Id", "NomeFuncao");
            #endregion

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(FuncionarioCadastroDto dto)
        {
            #region ViewBags
            ViewBag.Sex = new SelectList(new object[]
            {
                new {Name = "M", Value = "Masculino"},
                new {Name = "F", Value = "Feminino"}
            }, "Value", "Name");

            var funcoes = await _funcaoService.BuscarTodos();
            var setores = await _departamentoService.BuscarTodos();

            foreach(var depto in setores)
            {
                depto.NomeDepartamento += "/" + depto.SubDepartamento;
            }

            ViewBag.Funcs = new SelectList(funcoes, "Id", "NomeFuncao");
            ViewBag.Deptos = new SelectList(setores, "Id", "NomeDepartamento");
            #endregion

            if (ModelState.IsValid)
            {
                try
                {
                    await _funcionarioService.CadastrarFuncionarioAsync(dto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Nome", ex.Message);
                    return View(dto);
                }
            }
            return View(dto);
        }
    }
}