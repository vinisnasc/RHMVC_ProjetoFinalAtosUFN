using Estoque.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Domain
{
    public class RetiradasUniforme : BaseEntity
    {
        public Guid FuncionarioId { get; set; }
        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
        public Guid UniformeId { get; set; }
        [ForeignKey("UniformeId")]
        public virtual Uniforme Uniforme { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}
