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

        public async Task CriarArquivo(string nomeArquivo, DateTime data)
        {
            var pagamentos = await _unitOfWork.PagamentoRepository.PegarTodosPagamentosDataAsync(data);
            Path += nomeArquivo + ".txt";

            using (StreamWriter sw = File.CreateText(Path))
            {
                sw.WriteLine("nome - banco - agencia - valor");
                foreach (var pagamento in pagamentos)
                {
                    sw.WriteLine(pagamento.Funcionario.Nome + " - " + pagamento.Funcionario.ContaBancaria.Banco + 
                                 " - " + pagamento.Funcionario.ContaBancaria.Agencia + " - " + pagamento.Valor);
                }
            }
        }

    }
}
