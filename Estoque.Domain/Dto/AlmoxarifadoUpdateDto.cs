namespace Estoque.Domain.Dto
{
    public class AlmoxarifadoUpdateDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int MinimoEmEstoque { get; set; }
        public int? MaximoEmEstoque { get; set; }
    }
}
