namespace WEBAPP.MVC.Models.EstoqueModels.InputModels
{
    public class UniformeCadastroInputModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int MinimoEmEstoque { get; set; }
        public int? MaximoEmEstoque { get; set; }
        public DateTime TempoDeUso { get; set; }
    }
}
