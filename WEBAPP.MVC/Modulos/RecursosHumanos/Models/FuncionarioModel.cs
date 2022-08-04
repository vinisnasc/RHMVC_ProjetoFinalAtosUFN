using System.ComponentModel.DataAnnotations;
using WEBAPP.MVC.Modulos.RecursosHumanos.Models.Enum;

namespace WEBAPP.MVC.Modulos.RecursosHumanos.Models
{
    public class FuncionarioModel
    {
        public Guid? Id { get; set; }
        public int? Registro { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string FotoPerfil { get; set; }
        public string Cpf { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public Genero Sexo { get; set; }
        public string Funcao { get; set; }
        public Guid FuncaoId { get; set; }
        public string Departamento { get; set; }
        public Guid DepartamentoId { get; set; }
        public DateTime Demissao { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Admissao { get; set; }
        public EnderecoModel Endereco { get; set; }
        public ContaBancariaModel ContaBancaria { get; set; }

        public string PrimeiroNome()
        {
            return Nome.Split(" ")[0];
        }
    }

    public class ContaBancariaModel
    {
        public int Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
    }

    public class EnderecoModel
    {
        public string Cep { get; set; }
        public string Rua { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public MunicipioModel Municipio { get; set; }
    }

    public class MunicipioModel
    {
        public string NomeMunicipio { get; set; }
        public UfModel Uf { get; set; }
    }

    public class UfModel
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
    }
}