using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Responses;
using RH.Domain.Dtos.Views;
using RH.Domain.Entities;
using RH.Domain.Entities.Email;
using RH.Domain.Interfaces.Services;
using System.Net;

namespace RH.MVC.Controllers
{
    [Authorize]
    public class FuncionariosController : Controller
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IDepartamentoService _departamentoService;
        private readonly IFuncaoService _funcaoService;
        private readonly IPagamentosService _pagamentosService;
        private readonly IEmailSender _emailSender;

        public FuncionariosController(IFuncionarioService funcionarioService, IDepartamentoService departamentoService,
                                      IFuncaoService funcaoService, IPagamentosService pagamentosService,
                                      IEmailSender emailSender)
        {
            _funcionarioService = funcionarioService;
            _departamentoService = departamentoService;
            _funcaoService = funcaoService;
            _pagamentosService = pagamentosService;
            _emailSender = emailSender;
        }

        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return View(await _funcionarioService.BuscarTodosAtivosAsync());
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

        public async Task<IActionResult> Editar(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var funcionario = await _funcionarioService.BuscarPorId(id);

            if (funcionario == null)
                return NotFound();

            #region ViewBags
            ViewBag.Sex = new SelectList(new object[]
            {
                new {Name = "M", Value = "Masculino"},
                new {Name = "F", Value = "Feminino"}
            }, "Value", "Name", (funcionario.Sexo == 0 ? "Feminino" : "Masculino"));

            var funcoes = await _funcaoService.BuscarTodos();
            var setores = await _departamentoService.BuscarTodos();

            foreach (var depto in setores)
            {
                depto.NomeDepartamento += "/" + depto.SubDepartamento;
            }

            ViewBag.Funcs = new SelectList(funcoes, "Id", "NomeFuncao", funcionario.FuncaoId);
            ViewBag.Deptos = new SelectList(setores, "Id", "NomeDepartamento", funcionario.DepartamentoId);
            #endregion

            return View(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Guid id, FuncionarioEditarDadosPessoaisDto dto)
        {
            if (ModelState.IsValid)
            {
                await _funcionarioService.EditarDadosPessoaisAsync(id, dto);
                return RedirectToAction(nameof(Index));
            }

            return View(dto);
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

            foreach (var depto in setores)
            {
                depto.NomeDepartamento += "/" + depto.SubDepartamento;
            }

            ViewBag.Funcs = new SelectList(funcoes, "Id", "NomeFuncao");
            ViewBag.Deptos = new SelectList(setores, "Id", "NomeDepartamento", (dto.DepartamentoId == null ? setores[0] : dto.DepartamentoId));
            #endregion

            if (ModelState.IsValid)
            {
                try
                {
                    await _funcionarioService.CadastrarFuncionarioAsync(dto);
                    if (dto.Admissao > DateTime.Now)
                        SendEmail(dto);

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

        public async Task<IActionResult> Demitir(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();

            var funcionario = await _funcionarioService.BuscarPorId(id);

            if (funcionario == null)
                return NotFound();

            return View(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Demitir(FuncionarioDemitirDto dto, Guid id)
        {
            try
            {
               // await _funcionarioService.Demitir(id, dto.Demissao);
                await _pagamentosService.CalcularDemissao(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Demissao", ex.Message);
                return View(new FuncionarioViewDtoResult() { Id = id, Demissao = dto.Demissao });
            }
        }

        private async Task EnviarEmailBoasVindasAsync(FuncionarioCadastroDto funcionario)
        {
            Message mensagem = new(funcionario.Email, "Contratação", $"Prezado {funcionario.NomeSocial},\n\n" +
                $"Um dos momentos mais emocionantes e que todo RH gostaria de comunicar, " +
                $"é escolha e aprovação de um profissional para somar a nossa equipe. " +
                $"Então, queremos lhe dizer que você foi aprovado! Parabéns!!!\n\n" +
                $"Informamos que sua data de admissão será no dia {((DateTime)funcionario.Admissao).ToString("dd/MMMM/yyyy")} e que neste dia o sr(a). " +
                $"deverá comparecer no setor de RH ás 09:00, para ser encaminhado a seu respectivo setor.\n\n" +
                $"Qualquer dúvida, por favor, nos contate por e-mail.\n\n" +
                $"Cordialmente,\n" +
                $"Sua nova empresa LTDA.");

            await _emailSender.SendEmailAsync(mensagem);
        }

        private void SendEmail(FuncionarioCadastroDto funcionario) // OK
        {
            var destinatario = funcionario.Email;
            var nomeResponsavel = funcionario.Nome;
            var assunto = "Contratação";
            var conteudo = System.IO.File.ReadAllText($"{Directory.GetCurrentDirectory()}\\Views\\Emails\\BoasVindas.cshtml");
            conteudo = conteudo.Replace("{{username}}", nomeResponsavel);
            conteudo = conteudo.Replace("{{admissao}}", ((DateTime)funcionario.Admissao).ToString("dd/MM/yyyy"));
            var email = new Message(destinatario, assunto, conteudo);
            _emailSender.SendEmail(email);

        }
    }
}