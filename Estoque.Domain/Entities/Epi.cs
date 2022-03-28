namespace Estoque.Domain
{
    public class Epi : Produto
    {
        public int Ca { get; set; }
        public DateTime ValidadeCa { get; set; }
        public DateTime TempoDeUso { get; set; }
    }
}