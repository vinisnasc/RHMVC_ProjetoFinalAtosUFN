using System.ComponentModel.DataAnnotations;
using WEBAPP.MVC.Models.Enum;

namespace WEBAPP.MVC.Models.InputModel
{
    public class FuncionarioUpdate
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Necessário informar o nome do funcionário")]
        public string Nome { get; set; }

        [Display(Name = "Nome social")]
        public string? NomeSocial { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public Genero Sexo { get; set; }

        public string? FotoPerfil { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 digitos")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        public string RG { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Admissao { get; set; }
        // Departamento 
        [Display(Name = "Departamento")]
        public Guid DepartamentoId { get; set; }

        // Funcao
        [Display(Name = "Função")]
        public Guid FuncaoId { get; set; }
    }
}
