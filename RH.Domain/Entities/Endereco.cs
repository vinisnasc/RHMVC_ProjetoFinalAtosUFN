using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public Guid MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public IEnumerable<Funcionario> Funcionarios { get; set; }
    }
}
