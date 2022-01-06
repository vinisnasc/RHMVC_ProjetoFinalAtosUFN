using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Entities
{
    public class Uf : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }
        [Required]
        public string Nome { get; set; }
        public IEnumerable<Municipio> Municipios { get; set; }
    }
}
