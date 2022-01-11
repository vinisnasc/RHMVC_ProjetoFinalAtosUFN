using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Input
{
    public class FuncionarioDemitirDto
    {
        public string Nome { get; set; }

        [Display(Name = "Data de demissão")]
        [Required(ErrorMessage = "É necessário informar uma data de demissão.")]
        public DateTime Demissao { get; set; }
    }
}
