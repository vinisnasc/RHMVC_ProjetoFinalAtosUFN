namespace WEBAPP.MVC.Models.EstoqueModels.InputModels
{
    public class AlmoxarifadoCadastroInputModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int MinimoEmEstoque { get; set; }
        public int? MaximoEmEstoque { get; set; }
    }
}
