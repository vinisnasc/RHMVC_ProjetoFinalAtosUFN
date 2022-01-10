using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Input
{
    public class FuncaoAumentoSalarialDto
    {
        public double? AumentoPercentual { get; set; }
        public double? AumentoFixo { get; set; }
    }
}
