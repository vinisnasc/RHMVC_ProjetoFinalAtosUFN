using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Views
{
    public class FuncaoViewDtoResult
    {
        public Guid Id { get; set; }

        [Display(Name = "Função")]
        public string NomeFuncao { get; set; }

        [Display(Name = "Salário")]
        public double Salario { get; set; }

        [Display(Name = "Número de funcionários")]
        public int NumeroFuncionarios { get; set; }
    }
}
