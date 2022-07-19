namespace WEBAPP.MVC.Modulos.Estoque.Models.InputModels
{
    public class EpiCadastroInputModel
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int MinimoEmEstoque { get; set; }
        public int? MaximoEmEstoque { get; set; }
        public int CA { get; set; }
        public DateTime ValidadeCA { get; set; }
        public DateTime TempoDeUso { get; set; }
    }
}