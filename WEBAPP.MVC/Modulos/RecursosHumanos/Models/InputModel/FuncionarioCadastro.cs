using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WEBAPP.MVC.Modulos.RecursosHumanos.Models.Enum;

namespace WEBAPP.MVC.Modulos.RecursosHumanos.Models.InputModel
{
    public class FuncionarioCadastro
    {
        [Required]
        public string Nome { get; set; }

        [Display(Name ="Nome Social")]
        public string NomeSocial { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato de data incorreto")]
        [Display(Name ="Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Foto de perfil")]
        public string FotoPerfil { get; set; }

        [DisplayName("Foto de perfil")]
        public IFormFile FotoPerfilUpload { get; set; }

        [Required]
        public string Cpf { get; set; }

        [Required]
        public string RG { get; set; }

        [Display(Name = "E-mail")]
        [Required]
        public string Email { get; set; }

        [Required]
        public Genero Sexo { get; set; }

        [Display(Name = "Função")]
        [Required]
        public Guid FuncaoId { get; set; }

        [Display(Name = "Departamento")]
        [Required]
        public Guid DepartamentoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Admissao { get; set; }

        // Endereco
        public EnderecoModel Endereco { get; set; }

        // Banco
        [Display(Name = "Código bancário")]
        [Required]
        public int Banco { get; set; }

        [Required]
        [Display(Name = "Agência")]
        public string Agencia { get; set; }

        [Required]
        [Display(Name = "Conta Corrente")]
        public string ContaCorrente { get; set; }
    }
}