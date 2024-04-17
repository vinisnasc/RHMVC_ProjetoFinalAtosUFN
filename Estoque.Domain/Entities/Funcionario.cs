using Estoque.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Estoque.Domain
{
    public class Funcionario : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int Registro { get; set; }
        public string? Nome { get; set; }
        public string? Funcao { get; set; }
        public string? Departamento { get; set; }
    }
}
