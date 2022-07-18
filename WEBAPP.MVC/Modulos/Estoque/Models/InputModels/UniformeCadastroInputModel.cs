using System.ComponentModel.DataAnnotations;

namespace WEBAPP.MVC.Models.EstoqueModels.InputModels
{
    public class UniformeCadastroInputModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        [Display(Name = "Estoque mínimo")]
        public int MinimoEmEstoque { get; set; }

        [Display(Name = "Estoque máximo")]
        public int? MaximoEmEstoque { get; set; }

        [DataType(DataType.Time)]
        public DateTime TempoDeUso { get; set; }
    }
}
