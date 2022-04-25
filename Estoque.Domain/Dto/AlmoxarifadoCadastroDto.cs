namespace Estoque.Domain.Dto
{
    public class AlmoxarifadoCadastroDto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int MinimoEmEstoque { get; set; }
        public int? MaximoEmEstoque { get; set; }
    }
}
