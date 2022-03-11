using AutoMapper;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using RH.Domain.Entities;
using RH.Domain.Exceptions;
using RH.Domain.Interfaces.Repository;
using RH.Domain.Interfaces.Services;

namespace RH.Services
{
    public class FuncaoService : IFuncaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FuncaoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FuncaoViewDtoResult>> BuscarTodos()
        {
            var entities = await _unitOfWork.FuncaoRepository.SelecionarTudo();
            var dtos = _mapper.Map<List<FuncaoViewDtoResult>>(entities);
            foreach (var funcao in dtos)
            {
                funcao.NumeroFuncionarios = await _unitOfWork.FuncaoRepository.QuantidadeFuncionarioAsync(funcao.Id);
            }

            return dtos.OrderByDescending(x => x.NumeroFuncionarios).ToList();
        }

        public async Task<FuncaoViewDtoResult> CadastrarAsync(FuncaoCadastroDto dto)
        {
            if (await _unitOfWork.FuncaoRepository.ExisteFuncaoAsync(dto.NomeFuncao))
                throw new FuncaoJaExisteException();

            var entity = _mapper.Map<Funcao>(dto);
            await _unitOfWork.FuncaoRepository.Incluir(entity);
            return _mapper.Map<FuncaoViewDtoResult>(entity);
        }

        public async Task<FuncaoViewDtoResult> BuscarPorIdAsync(Guid id)
        {
            var entity = await _unitOfWork.FuncaoRepository.SelecionarPorId(id);
            return _mapper.Map<FuncaoViewDtoResult>(entity);
        }

        public async Task<FuncaoViewDtoResult> AtualizarAsync(FuncaoEditarDto dto)
        {
            if (await _unitOfWork.FuncaoRepository.ExisteFuncaoAsync(dto.NomeFuncao))
                throw new FuncaoJaExisteException();

            var entity = await _unitOfWork.FuncaoRepository.SelecionarPorId(dto.Id);
            entity = _mapper.Map(dto, entity);
            await _unitOfWork.FuncaoRepository.Alterar(entity);
            return _mapper.Map<FuncaoViewDtoResult>(entity);
        }

        public async Task AumentarSalarioAsync(Guid id, FuncaoEditarSalarioDto dto)
        {
            var funcao = await _unitOfWork.FuncaoRepository.SelecionarPorId(id);
            int numFuncionarios = await _unitOfWork.FuncaoRepository.QuantidadeFuncionarioAsync(id);

            if (dto.Salario < funcao.Salario && numFuncionarios != 0)
                throw new SalarioMenorException();

            funcao.Salario = dto.Salario;

            await _unitOfWork.FuncaoRepository.Alterar(funcao);
        }

        public async Task<IEnumerable<FuncionarioFuncaoView>> ListarFuncFuncaoAsync(Guid id)
        {
            var funcionarios = _unitOfWork.FuncaoRepository.BuscarFuncFuncao(id);
            var dtos = _mapper.Map<IEnumerable<FuncionarioFuncaoView>>(funcionarios);
            foreach (var func in dtos)
            {
                func.Departamento = (await _unitOfWork.DepartamentoRepository.SelecionarPorId(func.DepartamentoId)).NomeDepartamento;
                func.Funcao = _mapper.Map<FuncaoViewDtoResult>(await _unitOfWork.FuncaoRepository.SelecionarPorId(func.FuncaoId));
                func.Departamento += "/" + (await _unitOfWork.DepartamentoRepository.SelecionarPorId(func.DepartamentoId)).SubDepartamento;
            }

            return dtos;
        }

        public async Task RealizarAumentoAsync(FuncaoAumentoSalarialDto dto)
        {
            var funcoes = await _unitOfWork.FuncaoRepository.SelecionarTudo();

            if (dto.AumentoFixo != null)
            {
                if (dto.AumentoFixo < 0)
                    throw new SalarioMenorException();

                foreach (var funcao in funcoes)
                {
                    funcao.Salario += (double)dto.AumentoFixo;
                    await _unitOfWork.FuncaoRepository.Alterar(funcao);
                }
            }
            else
            {
                foreach (var funcao in funcoes)
                {
                    // Se o numero informado for maior que 1, significa que o input foi por exemplo 15%
                    // Caso não seja, o valor informado já foi em decimal
                    if (dto.AumentoPercentual < 0)
                        throw new SalarioMenorException();

                    else if (dto.AumentoPercentual > 1)
                      
                        funcao.Salario += funcao.Salario * ((double)dto.AumentoPercentual / 100);
                    else
                        funcao.Salario += funcao.Salario * (double)dto.AumentoPercentual;

                    await _unitOfWork.FuncaoRepository.Alterar(funcao);
                }
            }
        }
    }
}
