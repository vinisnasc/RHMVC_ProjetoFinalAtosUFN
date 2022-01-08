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

            foreach (var func in funcionarios)
            {
                Pagamento pagamento = new(dataPagamento, func.Id);
                pagamento.Valor = await CalcularSalarioMes(dataPagamento, func.Id);
                if (pagamento.Valor != 0)
                    await _unitOfWork.PagamentoRepository.Incluir(pagamento);
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

        private async Task<double> CalcularFerias(Funcionario func, DateTime data)
        {
            var numFeriasGozadas = await _unitOfWork.FeriasRepository.VerificarQuantidadeFeriasRecebidasAsync(func.Id);

            int quantidadeDireito = 0;
            int anoAdmissao = func.Admissao.Year;
            int mesAdmissao = func.Admissao.Month;
            int diaAdmissao = func.Admissao.Day;
            Funcao funcao = await _unitOfWork.FuncaoRepository.SelecionarPorId(func.FuncaoId);

            if (func.DataDemissao == null)
            {
                // Verifica o inicio das férias do funcionario
                DateTime primeiroDiaMesFerias = data.Month == 12 ?
                                     new DateTime(data.Year + 1, 1, 1) :
                                     new DateTime(data.Year, data.Month + 1, 1);

                var ultimoDiaTrabalhado = primeiroDiaMesFerias.AddDays(-1);

                // Verificar se o funcionário já tem um ano de servico
                if ((ultimoDiaTrabalhado.Subtract(func.Admissao)).TotalDays < 365)
                    throw new SemDireitoAFeriasException();

                var totalMesesTrabalhados = Math.Truncate(ultimoDiaTrabalhado.Subtract(func.Admissao).Days / (365.25 / 12));
                var totalMesesPendentes = totalMesesTrabalhados - numFeriasGozadas * 12;

                // Verifica se o funcionário tem um periodo aquisitivo completo
                if (totalMesesPendentes < 12)
                    throw new SemDireitoAFeriasException();

                return funcao.Salario + funcao.Salario / 3;
            }
            else if (func.DataDemissao != null)
            {
                var ultimoDiaTrabalhado = (DateTime)func.DataDemissao;
                var totalMesesTrabalhados = Math.Truncate(ultimoDiaTrabalhado.Subtract(func.Admissao).Days / (365.25 / 12));
                var totalMesesPendentes = totalMesesTrabalhados - numFeriasGozadas * 12;
                return funcao.Salario + funcao.Salario / 3;
            }
            return quantidadeDireito * funcao.Salario;
        }

        public async Task CalcularDemissao(Guid id)
        {
            var funcionario = await _unitOfWork.FuncionarioRepository.SelecionarPorId(id);

            if (funcionario.DataDemissao != null)
            {
                Demissao demissao = new();
                demissao.FuncionarioId = id;
                demissao.DataPagamento = ((DateTime)funcionario.DataDemissao).AddDays(10);
                demissao.ValorMes = await CalcularSalarioMes((DateTime)funcionario.DataDemissao, id);
                demissao.ValorDecimo = await CalcularDecimo(funcionario, (DateTime)funcionario.DataDemissao);
                demissao.ValorFerias = await CalcularFerias(funcionario, (DateTime)funcionario.DataDemissao);
            }
            else
                throw new Exception();
        }

        private async Task<double> CalcularSalarioMes(DateTime data, Guid id)
        {
            var funcionario = await _unitOfWork.FuncionarioRepository.SelecionarPorId(id);
            var salario = (await _unitOfWork.FuncaoRepository.SelecionarPorId(funcionario.FuncaoId)).Salario;

            if (funcionario.DataDemissao == null && !await _unitOfWork.PagamentoRepository.VerificaSeExistePagamentoAsync(data, id))
            {
                // Para pagamento normal, calcular mes anterior, para demissao calcular mes corrente
                DateTime primeiroDiaMesTrabalhado = data.Month == 1 ?
                                     new DateTime(data.Year - 1, 12, 1) :
                                     new DateTime(data.Year, data.Month - 1, 1);
                DateTime ultimoDiaMesTrabalhado = new DateTime(primeiroDiaMesTrabalhado.Year,
                                                               primeiroDiaMesTrabalhado.Month,
                                                               DateTime.DaysInMonth(primeiroDiaMesTrabalhado.Year, primeiroDiaMesTrabalhado.Month));

                if (funcionario.Admissao < primeiroDiaMesTrabalhado)
                    return salario;

                else if (funcionario.Admissao > ultimoDiaMesTrabalhado)
                    return 0;

                else if (funcionario.Admissao > primeiroDiaMesTrabalhado)
                {
                    var diasNoMes = ultimoDiaMesTrabalhado.Day;
                    var diaInicio = funcionario.Admissao.Day;
                    var diasTrabalhados = diasNoMes - diaInicio + 1;
                    return salario / 30 * diasTrabalhados;
                }
            }
            else if (funcionario.DataDemissao != null)
            {
                // Calcula somente para a rescisão
                if (((DateTime)funcionario.DataDemissao).Month == data.Month && ((DateTime)funcionario.DataDemissao).Year == data.Year)
                    return salario / 30 * ((DateTime)funcionario.DataDemissao).Day;
            }
            return 0;
        }
    }
}
