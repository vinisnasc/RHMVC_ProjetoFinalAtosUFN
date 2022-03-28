using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Estoque.Domain
{
    [Table("Retiradas_Almoxarifado")]
    public class RetiradasAlmoxarifado
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FuncionarioId { get; set; }
        [ForeignKey("FuncionarioId")]
        public virtual Funcionario Funcionario { get; set; }
        public Guid AlmoxarifadoId { get; set; }
        [ForeignKey("AlmoxarifadoId")]
        public virtual Almoxarifado Almoxarifado { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}
