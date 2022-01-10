using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Views
{
    public class FuncionarioFuncaoView
    {
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Departamento { get; set; }
        public FuncaoViewDtoResult Funcao { get; set; }
        public Guid FuncaoId { get; set; }
        public Guid DepartamentoId { get; set; }
    }
}
