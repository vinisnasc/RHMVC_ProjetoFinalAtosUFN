using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Views
{
    public class FuncaoViewDtoResult
    {
        public Guid Id { get; set; }
        public string NomeFuncao { get; set; }
        public double Salario { get; set; }
        public int NumeroFuncionarios { get; set; }
    }
}
