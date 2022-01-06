using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Entities
{
    public class Ferias : BaseEntity
    {
        public DateTime DataPagamento { get; set; }
        public double Valor { get; set; }
        public Guid FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public Ferias(DateTime dataPagamento, Guid funcionarioId)
        {
            DataPagamento = dataPagamento;
            FuncionarioId = funcionarioId;
        }
    }
}
