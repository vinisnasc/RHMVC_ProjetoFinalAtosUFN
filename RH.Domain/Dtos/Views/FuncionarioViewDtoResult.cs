using RH.Domain.Entities;
using RH.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Views
{
    public class FuncionarioViewDtoResult
    {
        public Guid Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? FotoPerfil { get; set; }
        public string Cpf { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public Genero Sexo { get; set; }
        public string Funcao { get; set; }
        public Guid FuncaoId { get; set; }
        public string Departamento { get; set; }
        public Guid DepartamentoId { get; set; }
        public DateTime Demissao { get; set; }
        public DateTime? Admissao { get; set; }

        // Endereco
        public Guid EnderecoId { get; set; }
        public EnderecoViewResult Endereco { get; set; }

        // Banco
        public ContaBancariaViewResult ContaBancaria { get; set; }
        public Guid ContaBancariaId { get; set; }
    }

    public class ContaBancariaViewResult
    {
        public int Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
    }

    public class EnderecoViewResult
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public Guid MunicipioId { get; set; }
        public MunicipioViewResult Municipio { get; set; }
    }

    public class MunicipioViewResult
    {
        public string NomeMunicipio { get; set; }
        public Guid UfId { get; set; }
        public UfViewResult Uf { get; set; }
    }

    public class UfViewResult
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
    }
}
