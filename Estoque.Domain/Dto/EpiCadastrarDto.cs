using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Dto
{
    public class EpiCadastrarDto
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
