using System.ComponentModel.DataAnnotations;
using WEBAPP.MVC.Models.Enum;

namespace WEBAPP.MVC.Models.InputModel
{
    public class FuncionarioCadastro
    {
        public string Nome { get; set; }
        public string? NomeSocial { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string FotoPerfil { get; set; }
        public string Cpf { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public Genero Sexo { get; set; }
        public Guid FuncaoId { get; set; }
        public Guid DepartamentoId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Admissao { get; set; }

        // Endereco
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }

        // Banco
        public int Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
    }
}
