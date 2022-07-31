using KissLog;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBAPP.MVC.Models;

namespace WEBAPP.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IKLogger _logger;

        public HomeController(IKLogger logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.Debug("Alguem logou");
            return View();
        }

        public IActionResult Estoque()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[Route("erro/{id:lenght(3,3)}")]
        public IActionResult Error(int id)
        {
            ErrorViewModel modelError = new();
            if(id == 500)
            {
                modelError.Menssagem = "Ocorreu um erro, tente novamente mais tarde";
                modelError.ErroCode = id;
                modelError.Titulo = "Ocorreu um erro!";
            }
            else if(id == 404)
            {
                modelError.Menssagem = "A pagina que voce esta procurando nao existe<br/> Emcaso de duvida procure o suporte";
                modelError.ErroCode = id;
                modelError.Titulo = "Ops, pagina nao encontrada!";
            }
            else if(id ==403)
            {
                modelError.Menssagem = "Voce nao tem permissao";
                modelError.ErroCode = id;
                modelError.Titulo = "Acesso negado";
            }
            else
            {
                return StatusCode(404);
            }
            return View(modelError);
        }

        [Authorize]
        public IActionResult Login()
        {
            //_logger.ToString($"Usuario Logado{User.Identity.Name}");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}