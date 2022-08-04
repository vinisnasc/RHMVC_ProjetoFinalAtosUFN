using RH.Domain.Dtos.Views;
using RH.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace RH.Domain.Dtos.Input
{
    public class FuncionarioCadastroDto
    {
        // Funcionario
        public string Nome { get; set; }
        public string? NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string FotoPerfil { get; set; }
        public string Cpf { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public Genero Sexo { get; set; }
        public DateTime? Admissao { get; set; }

        // Conta Bancaria
        [Display(Name = "Codigo do banco")]
        public int Banco { get; set; }

        [Required]
        public string Agencia { get; set; }

        [Required]
        public string ContaCorrente { get; set; }

        // Endereco
        public EnderecoDTO Endereco { get; set; }

        // Departamento 
        public Guid DepartamentoId { get; set; }

        // Funcao
        [Display(Name = "Função")]
        public Guid FuncaoId { get; set; }

        [Display(Name = "Departamento")]
        public List<DepartamentoViewDtoResult>? Departamentos { get; set; }
    }

    public class EnderecoDTO
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioDTO Municipio { get; set; }
    }

    public class MunicipioDTO
    {
        public string NomeMunicipio { get; set; }
        public UfDTO Uf { get; set; }
    }

    public class UfDTO
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
    }
}
