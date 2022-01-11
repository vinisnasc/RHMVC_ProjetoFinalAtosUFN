using RH.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Input
{
    public class FuncionarioEditarDadosPessoaisDto
    {
        [Required(ErrorMessage = "Necessário informar o nome do funcionário")]
        public string Nome { get; set; }

        [Display(Name = "Nome social")]
        public string? NomeSocial { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 digitos")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string RG { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public Genero Sexo { get; set; }

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
