using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Entities
{
    public class Municipio : BaseEntity
    {
        [Required]
        public string NomeMunicipio { get; set; }
        [Required]
        public Guid UfId { get; set; }
        public Uf Uf { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
    }
}
