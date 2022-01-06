using System.ComponentModel.DataAnnotations;

namespace RH.Domain.Dtos.Views
{
    public class DepartamentoViewDtoResult
    {
        public Guid Id { get; set; }
        [Display(Name = "Departamento")]
        public string NomeDepartamento { get; set; }
        [Display(Name = "Sub-Departamento")]
        public string SubDepartamento { get; set; }
        [Display(Name = "Número de Funcionarios")]
        public int NumeroFuncionario { get; set; }

        public override string ToString()
        {
            return (NomeDepartamento + "/" + SubDepartamento).ToLower();
        }
    }
}
