using Estoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain
{
    public abstract class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; } = 0;
        public double Valor { get; set; }
        public int MinimoEmEstoque { get; set; }
        public int? MaximoEmEstoque { get; set; }

    }
}
