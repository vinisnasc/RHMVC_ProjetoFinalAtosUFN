namespace WEBAPP.MVC.Modulos.Estoque.Models
{
    public class AlmoxarifadoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public int MinimoEmEstoque { get; set; }
        public int? MaximoEmEstoque { get; set; }
    }
}