using RH.Domain.Dtos.Views;
using RH.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Input
{
    public class FuncionarioCadastroDto
    {
        // Funcionario
        [Required(ErrorMessage = "Necessário informar o nome do funcionário")]
        public string Nome { get; set; }

        [Display(Name = "Nome social")]
        public string? NomeSocial { get; set; }

        [Required]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(11, MinimumLength =11, ErrorMessage = "CPF deve ter 11 digitos")]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        public string RG { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public Genero Sexo { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Admissao { get; set; }

        // Conta Bancaria
        [Display(Name = "Codigo do banco")]
        public int Banco { get; set; }

        [Required]
        public string Agencia { get; set; }

        [Required]
        public string ContaCorrente { get; set; }

        // Endereco
        [Required]
        public string Cep { get; set; }

        [Required]
        public int Numero { get; set; }
        public string? Complemento { get; set; }

        // Departamento 
        [Display(Name = "Departamento")]
        public Guid DepartamentoId { get; set; }

        // Funcao
        [Display(Name = "Função")]
        public Guid FuncaoId { get; set; }

        [Display(Name = "Departamento")]
        public List<DepartamentoViewDtoResult>? Departamentos { get; set; }
    }
}
