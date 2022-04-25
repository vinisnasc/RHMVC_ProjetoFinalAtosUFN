namespace Estoque.Domain
{
    public class RetiradaAlmoxarifado
    {
        public Guid FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public Guid AlmoxarifadoId { get; set; }
        public virtual Almoxarifado Almoxarifado { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}
