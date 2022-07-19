using System.ComponentModel.DataAnnotations;

namespace WEBAPP.MVC.Modulos.RecursosHumanos.Models.InputModel
{
    public class FuncaoAtualizacao
    {
        public Guid Id { get; set; }

        [Display(Name = "Função")]
        public string NomeFuncao { get; set; }
    }
}