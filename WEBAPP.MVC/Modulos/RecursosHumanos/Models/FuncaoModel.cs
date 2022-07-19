using System.ComponentModel.DataAnnotations;

namespace WEBAPP.MVC.Modulos.RecursosHumanos.Models
{
    public class FuncaoModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Função")]
        public string NomeFuncao { get; set; }

        [Range(1000, 100000)]
        [Display(Name = "Salário")]
        public double Salario { get; set; }

        [Display(Name = "Quantidade de funcionários")]
        public int NumeroFuncionarios { get; set; }
    }
}