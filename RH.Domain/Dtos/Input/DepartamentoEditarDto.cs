using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Input
{
    public class DepartamentoEditarDto
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Nome de setor deve ter no minimo 2 e no máximo 50 letras!")]
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "É necessário informar um departamento")]
        public string NomeDepartamento { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Nome de setor deve ter no minimo 2 e no máximo 50 letras!")]
        [Display(Name = "Sub-Departamento")]
        [Required(ErrorMessage = "É necessário informar um sub-departamento")]
        public string SubDepartamento { get; set; }
    }
}
