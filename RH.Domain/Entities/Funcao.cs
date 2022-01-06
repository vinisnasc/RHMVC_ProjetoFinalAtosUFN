using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Entities
{
    public class Funcao : BaseEntity
    {
        public string NomeFuncao { get; set; }
        public double Salario { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}
