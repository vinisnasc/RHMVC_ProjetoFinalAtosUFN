using Microsoft.EntityFrameworkCore;
using RH.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace RH.Domain.Entities
{
    public class Funcionario : BaseEntity
    {
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string? NomeSocial { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public DateTime Admissao { get; set; }
        public Genero Sexo { get; set; }
        public DateTime? DataDemissao { get; set; }
        public bool Ativo { get; set; } = true;

        // Relacionamentos
        public Guid? DemissaoId { get; set; }
        public Demissao Demissao { get; set; }
        public Guid ContaBancariaId { get; set; }
        public ContaBancaria ContaBancaria { get; set; }
        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public Guid DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public Guid FuncaoId { get; set; }
        public Funcao Funcao { get; set; }
        public List<DecimoTerceiro> DecimoTerceiro { get; set; }
        public List<Ferias> Ferias { get; set; }
        public List<Pagamento> Pagamentos { get; set; }
    }
}