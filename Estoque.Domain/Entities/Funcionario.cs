using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Estoque.Domain
{
    public class Funcionario : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public string Departamento { get; set; }
    }
}
