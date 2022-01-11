using RH.Domain.Entities;
using RH.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Services
{
    public class ExportadorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public string Path = @"C:\Users\Vini\Desktop\";

        public ExportadorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CriarArquivoPagamento(string nomeArquivo, DateTime data)
        {
            var pagamentos = await _unitOfWork.PagamentoRepository.PegarTodosPagamentosDataAsync(data);
            Path += nomeArquivo + ".txt";

            using (StreamWriter sw = File.CreateText(Path))
            {
                sw.WriteLine($"Folha de pagamento - mês referência = {data.AddMonths(-1).ToString("MMMM")}");
                sw.WriteLine("nome - banco - agencia - valor");
                foreach (var pagamento in pagamentos)
                {
                    sw.WriteLine(pagamento.Funcionario.Nome + " - " + pagamento.Funcionario.ContaBancaria.Banco +
                                 " - " + pagamento.Funcionario.ContaBancaria.Agencia + " - " + pagamento.Valor);
                }
            }
        }

        public async Task CriarArquivoDecimo(string nomeArquivo, DateTime data)
        {
            var decimo = await _unitOfWork.DecimoTerceiroRepository.PegarTodosDecimosDataAsync(data);
            Path += nomeArquivo + ".txt";

            using (StreamWriter sw = File.CreateText(Path))
            {
                if (data.Month != 12)
                    sw.WriteLine($"Folha de pagamento - 1ª Parcela 13º. Pagamento em: {data.ToString("dd/MMMM/yyyy")}");

                else
                    sw.WriteLine($"Folha de pagamento - 2ª Parcela 13º. Pagamento em: {data.ToString("dd/MMMM/yyyy")}");

                sw.WriteLine("nome - banco - agencia - valor");
                foreach (var pagamento in decimo)
                {
                    sw.WriteLine(pagamento.Funcionario.Nome + " - " + pagamento.Funcionario.ContaBancaria.Banco +
                                 " - " + pagamento.Funcionario.ContaBancaria.Agencia + " - " + pagamento.Valor);
                }
            }
        }
    }
}
