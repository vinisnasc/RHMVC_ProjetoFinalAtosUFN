using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RH.Domain.Dtos;
using RH.Domain.Interfaces.Services;

namespace RH.API.Controllers
{
    /// <summary>
    /// Controller base onde todas as outras herdarão
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class BaseController : ControllerBase
    {
        private readonly INotificador _notificador;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="notificador"></param>
        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        /// <summary>
        /// Verifica se existe mensagens de erro no notificador
        /// </summary>
        /// <returns></returns>
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        /// <summary>
        /// Retorna mensagem customizada
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        /// <summary>
        /// Verifica se o modelState está valido, se sim, retorna a resposta customizada, se nao, envia os erros para o notificador
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        /// <summary>
        /// Envia os erros de modelstate de uma model para o notificador
        /// </summary>
        /// <param name="modelState"></param>
        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        /// <summary>
        /// Envia um erro para o notificador
        /// </summary>
        /// <param name="mensagem"></param>
        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
