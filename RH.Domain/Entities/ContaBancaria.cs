namespace RH.Domain.Entities
{
    public class ContaBancaria : BaseEntity
    {
        public int Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public List<Funcionario> Funcionarios { get; set; }

        public ContaBancaria() { }
    }
}