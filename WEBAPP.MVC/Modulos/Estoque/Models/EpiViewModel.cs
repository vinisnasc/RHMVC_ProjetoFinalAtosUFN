namespace WEBAPP.MVC.Modulos.Estoque.Models
{
    public class EpiViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public int CA { get; set; }
    }
}