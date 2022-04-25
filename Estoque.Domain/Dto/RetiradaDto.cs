using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Dto
{
    public class RetiradaDto
    {
        public Guid FuncionarioId { get; set; }
        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataRetirada { get; set; }
    }
}
