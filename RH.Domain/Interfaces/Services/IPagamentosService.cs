using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Services
{
    public interface IPagamentosService
    {
        Task GerarDecimoTerceiroAsync(DateTime dataPagamento);
        Task GerarFeriasAsync(DateTime dataPagamento, Guid idFunc);
        Task GerarFolhaPagamentoAsync(DateTime dataPagamento);
        Task CalcularDemissao(Guid id);
    }
}
