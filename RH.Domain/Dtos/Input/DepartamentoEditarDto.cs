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

        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "É necessário informar um departamento")]
        public string NomeDepartamento { get; set; }

        [Display(Name = "Sub-Departamento")]
        [Required(ErrorMessage = "É necessário informar um sub-departamento")]
        public string SubDepartamento { get; set; }
    }
}
