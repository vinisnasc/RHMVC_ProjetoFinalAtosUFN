using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Dto
{
    public class EpiDto
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public int CA { get; set; }
    }
}
