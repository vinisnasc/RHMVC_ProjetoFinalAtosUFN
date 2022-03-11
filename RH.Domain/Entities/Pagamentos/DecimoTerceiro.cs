namespace RH.Domain.Entities
{
    public class DecimoTerceiro : BaseEntity
    {
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public Guid FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public DecimoTerceiro(DateTime dataPagamento, Guid funcionarioId)
        {
            DataPagamento = dataPagamento;
            FuncionarioId = funcionarioId;
        }
    }
}
