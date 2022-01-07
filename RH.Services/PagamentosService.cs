using RH.Domain.Entities;
using RH.Domain.Exceptions;
using RH.Domain.Interfaces.Repository;
using RH.Domain.Interfaces.Services;

namespace RH.Services
{
    public class PagamentosService : IPagamentosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PagamentosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task GerarFolhaPagamentoAsync(DateTime dataPagamento)
        {
            var funcionarios = await _unitOfWork.FuncionarioRepository.SelecionarTudo();

            // Variaveis para verificação do mês trabalhado
            DateTime primeiroDiaMesTrabalhado = dataPagamento.Month == 1 ? 
                                     new DateTime(dataPagamento.Year - 1, 12, 1) : 
                                     new DateTime(dataPagamento.Year, dataPagamento.Month - 1, 1);
            DateTime ultimoDiaMesTrabalhado = new DateTime(primeiroDiaMesTrabalhado.Year, 
                                                           primeiroDiaMesTrabalhado.Month,
                                                           DateTime.DaysInMonth(primeiroDiaMesTrabalhado.Year, primeiroDiaMesTrabalhado.Month));

            foreach (var func in funcionarios)
            {
                // Verifica se o funcionário nao esta demitido e se não existe pagamento para a data informada
                if (func.Demissao == null && !await _unitOfWork.PagamentoRepository.VerificaSeExistePagamentoAsync(dataPagamento, func.Id))
                {
                    Pagamento pagamento = new(dataPagamento, func.Id);
                    var salario = (await _unitOfWork.FuncaoRepository.SelecionarPorId(func.FuncaoId)).Salario;

                    if (func.Admissao < primeiroDiaMesTrabalhado)
                        pagamento.Valor = salario;
                    
                    else if(func.Admissao > primeiroDiaMesTrabalhado)
                    {
                        var diasNoMes = ultimoDiaMesTrabalhado.Day;
                        var diaInicio = func.Admissao.Day;
                        var diasTrabalhados = diasNoMes - diaInicio + 1;
                        pagamento.Valor = salario / 30 * diasTrabalhados;
                    }

                    await _unitOfWork.PagamentoRepository.Incluir(pagamento);
                }
            }
        }

        public async Task GerarDecimoTerceiroAsync(DateTime dataPagamento)
        {
            var funcionarios = await _unitOfWork.FuncionarioRepository.SelecionarTudo();
            foreach (var func in funcionarios)
            {
                DecimoTerceiro decimoTerceiro = new(dataPagamento, func.Id);
                decimoTerceiro.Valor = await CalcularDecimo(func, dataPagamento);

                if (decimoTerceiro.Valor != 0)
                    await _unitOfWork.DecimoTerceiroRepository.Incluir(decimoTerceiro);
            }
        }

        private async Task<double> CalcularDecimo(Funcionario func, DateTime pagamento)
        {
            int quantidade;
            int anoAdmissao = func.Admissao.Year;
            int mesAdmissao = func.Admissao.Month;
            int diaAdmissao = func.Admissao.Day;
            Funcao funcao = await _unitOfWork.FuncaoRepository.SelecionarPorId(func.FuncaoId);

            int diasMesAdmissao = DateTime.DaysInMonth(anoAdmissao, mesAdmissao);

            if (anoAdmissao > pagamento.Year)
            {
                quantidade = 0;
            }
            else if (anoAdmissao != pagamento.Year)
            {
                quantidade = 12;
            }
            else if (diasMesAdmissao - diaAdmissao >= 15)
            {
                quantidade = 13 - mesAdmissao;
            }
            else
            {
                quantidade = 12 - mesAdmissao;
            }

            return funcao.Salario / 12 * quantidade;
        }

        public async Task GerarFeriasAsync(DateTime dataPagamento, Guid idFunc)
        {
            var funcionario = await _unitOfWork.FuncionarioRepository.SelecionarPorId(idFunc);
            
                Ferias ferias = new(dataPagamento, idFunc);
                ferias.Valor = await CalcularFerias(funcionario, dataPagamento);

                if (ferias.Valor != 0)
                    await _unitOfWork.FeriasRepository.Incluir(ferias);
            
        }

        private async Task<double> CalcularFerias(Funcionario func, DateTime pagamento)
        {
            var numFeriasGozadas = await _unitOfWork.FeriasRepository.VerificarQuantidadeFeriasRecebidasAsync(func.Id);

            int quantidade = 0;
            int anoAdmissao = func.Admissao.Year;
            int mesAdmissao = func.Admissao.Month;
            int diaAdmissao = func.Admissao.Day;
            Funcao funcao = await _unitOfWork.FuncaoRepository.SelecionarPorId(func.FuncaoId);

            if ((DateTime.Now.Subtract(func.Admissao)).TotalDays < 365)
                throw new SemDireitoAFeriasException();

            return quantidade * funcao.Salario;
        }

        public async Task CalcularDemissao(Guid id)
        {
            var funcionario = await _unitOfWork.FuncionarioRepository.SelecionarPorId(id);

            //double salarioMes = 
        }

        private async Task<double> CalcularSalarioMes(DateTime dataPagamento, Guid id)
        {
            var funcionario = await _unitOfWork.FuncionarioRepository.SelecionarPorId(id);
            DateTime primeiroDiaMesTrabalhado = dataPagamento.Month == 1 ?
                                     new DateTime(dataPagamento.Year - 1, 12, 1) :
                                     new DateTime(dataPagamento.Year, dataPagamento.Month - 1, 1);
            DateTime ultimoDiaMesTrabalhado = new DateTime(primeiroDiaMesTrabalhado.Year,
                                                           primeiroDiaMesTrabalhado.Month,
                                                           DateTime.DaysInMonth(primeiroDiaMesTrabalhado.Year, primeiroDiaMesTrabalhado.Month));

            if (funcionario.Demissao == null && !await _unitOfWork.PagamentoRepository.VerificaSeExistePagamentoAsync(dataPagamento, id))
            {
                Pagamento pagamento = new(dataPagamento, id);
                var salario = (await _unitOfWork.FuncaoRepository.SelecionarPorId(funcionario.FuncaoId)).Salario;

                if (funcionario.Admissao < primeiroDiaMesTrabalhado)
                    pagamento.Valor = salario;

                else if (funcionario.Admissao > primeiroDiaMesTrabalhado)
                {
                    var diasNoMes = ultimoDiaMesTrabalhado.Day;
                    var diaInicio = funcionario.Admissao.Day;
                    var diasTrabalhados = diasNoMes - diaInicio + 1;
                    pagamento.Valor = salario / 30 * diasTrabalhados;
                }

                await _unitOfWork.PagamentoRepository.Incluir(pagamento);
            }
            {

            }

            return 0;
        }
    }
}
