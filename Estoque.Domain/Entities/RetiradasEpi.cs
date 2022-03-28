using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain
{
    [Table("Retiradas_Epi")]
    public class RetiradasEpi
    {
        public Guid FuncionarioId { get; set; }
        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
        public Guid EpiId { get; set; }
        [ForeignKey("EpiId")]
        public virtual Epi Epi { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}
