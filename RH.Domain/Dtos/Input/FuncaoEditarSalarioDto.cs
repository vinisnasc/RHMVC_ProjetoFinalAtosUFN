using System.ComponentModel.DataAnnotations;

namespace RH.Domain.Dtos.Input
{
    public class FuncaoEditarSalarioDto
    {
        [Display(Name = "Salário")]
        [Required(ErrorMessage = "É necessário informar o valor do salário da função!")]
        public double Salario { get; set; }
    }
}
