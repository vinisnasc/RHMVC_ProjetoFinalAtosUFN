namespace Estoque.Domain.Dto
{
    public class UniformeCadastroDto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int MinimoEmEstoque { get; set; }
        public int? MaximoEmEstoque { get; set; }
        public DateTime TempoDeUso { get; set; }
    }
}
