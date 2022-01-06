using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Input
{
    public class PagamentosDto
    {
        public Guid FuncionarioId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataPagamento { get; set; }
    }
}
