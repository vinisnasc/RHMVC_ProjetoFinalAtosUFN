using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Dtos.Views
{
    public class FuncionarioDepartamentoView
    {
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Funcao { get; set; }
        public DepartamentoViewDtoResult Departamento { get; set; }
        public Guid FuncaoId { get; set; }
        public Guid DepartamentoId { get; set; }
    }
}
