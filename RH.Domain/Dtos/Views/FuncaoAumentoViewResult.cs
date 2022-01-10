using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Views
{
    public class FuncaoAumentoViewResult
    {
        public double AumentoPercentual { get; set; }
        public double AumentoFixo { get; set; }
        public List<FuncaoViewDtoResult> Funcoes { get; set; }
    }
}
