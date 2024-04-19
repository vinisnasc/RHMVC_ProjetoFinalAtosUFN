using System.ComponentModel.DataAnnotations;

namespace RH.Domain.Dtos.Input
{
    public class DepartamentoCadastroDto
    {
        [Display(Name = "Departamento")]
        [StringLength(50, MinimumLength = 3, ErrorMessage ="Nome de setor deve ter no minimo 2 e no máximo 50 letras!")]
        [Required(ErrorMessage = "É necessário informar um departamento")]
        [DeniedValues("string", ErrorMessage = "É necessário informar um departamento")]
        public string NomeDepartamento { get; set; }

        [Display(Name = "Sub-Departamento")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome do subdepartamento deve ter no minimo 2 e no máximo 50 letras!")]
        [Required(ErrorMessage = "É necessário informar um sub-departamento")]
        [DeniedValues("string", ErrorMessage = "É necessário informar um departamento")]
        public string SubDepartamento { get; set; }
    }
}