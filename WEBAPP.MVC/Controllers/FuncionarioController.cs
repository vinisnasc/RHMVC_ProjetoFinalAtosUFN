using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEBAPP.MVC.Models;
using WEBAPP.MVC.Models.InputModel;
using WEBAPP.MVC.Services.IServices;

namespace WEBAPP.MVC.Controllers
{
    [Authorize]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IDepartamentoService _departamentoService;
        private readonly IFuncaoService _funcaoService;

        public FuncionarioController(IFuncionarioService funcionarioService, IDepartamentoService departamentoService, IFuncaoService funcaoService)
        {
            _funcionarioService = funcionarioService;
            _departamentoService = departamentoService;
            _funcaoService = funcaoService;
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await _funcionarioService.BuscarTodosAtivos(accessToken);
            return View(result);
        }

        public async Task<IActionResult> Cadastrar()
        {
            ViewBag.Sex = new SelectList(new object[]
            {
                new {Name = "M", Value = "Masculino"},
                new {Name = "F", Value = "Feminino"}
            }, "Value", "Name");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var setores = await _departamentoService.BuscarTodos(accessToken);
            var funcoes = await _funcaoService.BuscarTodos(accessToken);

            foreach (var depto in setores)
            {
                depto.NomeDepartamento += "/" + depto.SubDepartamento;
            }

            ViewBag.Deptos = new SelectList(setores, "Id", "NomeDepartamento");
            ViewBag.Funcs = new SelectList(funcoes, "Id", "NomeFuncao");

            return View(new FuncionarioCadastro { Admissao = DateTime.Now, Nome = "Lara", Sexo = Models.Enum.Genero.Feminino, Agencia = "423", ContaCorrente = "5455", Banco = 45, Cep = "03579240", RG = "377603908", FotoPerfil = "http://ilvideogioco.files.wordpress.com/2010/12/jan2011_cover_b_frontd.jpg", Cpf = "40931577828" });
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(FuncionarioCadastro model)
        {
            #region ViewBags
            ViewBag.Sex = new SelectList(new object[]
            {
                new {Name = "M", Value = "Masculino"},
                new {Name = "F", Value = "Feminino"}
            }, "Value", "Name");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var funcoes = await _funcaoService.BuscarTodos(accessToken);
            var setores = (await _departamentoService.BuscarTodos(accessToken)).ToList();

            foreach (var depto in setores)
            {
                depto.NomeDepartamento += "/" + depto.SubDepartamento;
            }

            ViewBag.Funcs = new SelectList(funcoes, "Id", "NomeFuncao");
            ViewBag.Deptos = new SelectList(setores, "Id", "NomeDepartamento", (model.DepartamentoId == null ? setores[0] : model.DepartamentoId));
            #endregion

            if (ModelState.IsValid)
            {
                await _funcionarioService.Create(model, accessToken);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var result = await _funcionarioService.FindById(id, accessToken);
            return View(result);
        }

        public async Task<IActionResult> Atualizar(Guid id)
        {
            ViewBag.Sex = new SelectList(new object[]
            {
                new {Name = "M", Value = "Masculino"},
                new {Name = "F", Value = "Feminino"}
            }, "Value", "Name");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var setores = await _departamentoService.BuscarTodos(accessToken);
            var funcoes = await _funcaoService.BuscarTodos(accessToken);

            foreach (var depto in setores)
            {
                depto.NomeDepartamento += "/" + depto.SubDepartamento;
            }

            ViewBag.Deptos = new SelectList(setores, "Id", "NomeDepartamento");
            ViewBag.Funcs = new SelectList(funcoes, "Id", "NomeFuncao");

            var model = await _funcionarioService.FindById(id, accessToken);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(FuncionarioUpdate model)
        {
            #region ViewBags
            ViewBag.Sex = new SelectList(new object[]
            {
                new {Name = "M", Value = "Masculino"},
                new {Name = "F", Value = "Feminino"}
            }, "Value", "Name");

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var funcoes = await _funcaoService.BuscarTodos(accessToken);
            var setores = (await _departamentoService.BuscarTodos(accessToken)).ToList();

            foreach (var depto in setores)
            {
                depto.NomeDepartamento += "/" + depto.SubDepartamento;
            }

            ViewBag.Funcs = new SelectList(funcoes, "Id", "NomeFuncao");
            ViewBag.Deptos = new SelectList(setores, "Id", "NomeDepartamento", (model.DepartamentoId == null ? setores[0] : model.DepartamentoId));
            #endregion

            if (ModelState.IsValid)
            {
                await _funcionarioService.Update(model, accessToken);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
