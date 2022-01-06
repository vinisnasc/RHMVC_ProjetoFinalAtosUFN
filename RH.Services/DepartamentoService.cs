using AutoMapper;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Views;
using RH.Domain.Entities;
using RH.Domain.Exceptions;
using RH.Domain.Interfaces.Repository;
using RH.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartamentoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<DepartamentoViewDtoResult>> BuscarTodos()
        {
            var entities = await _unitOfWork.DepartamentoRepository.SelecionarTudo();
            var dtos = _mapper.Map<List<DepartamentoViewDtoResult>>(entities);
            foreach(var departamento in dtos)
            {
                departamento.NumeroFuncionario = await _unitOfWork.DepartamentoRepository.QuantidadeFuncionarioAsync(departamento.Id);
            }

            return dtos.OrderByDescending(x => x.NumeroFuncionario).ToList();
        }

        public async Task<DepartamentoViewDtoResult> BuscarPorIdAsync(Guid id)
        {
            var entity = await _unitOfWork.DepartamentoRepository.SelecionarPorId(id);
            return _mapper.Map<DepartamentoViewDtoResult>(entity);
        }

        public async Task CadastrarAsync(DepartamentoCadastroDto dto)
        {
            if(await _unitOfWork.DepartamentoRepository.ExisteDepto(dto.NomeDepartamento, dto.SubDepartamento))
                throw new DepartamentoJaExisteException();
            
            var entity = _mapper.Map<Departamento>(dto);
            await _unitOfWork.DepartamentoRepository.Incluir(entity);
        }

        public async Task AtualizarAsync(Guid id, DepartamentoEditarDto dto)
        {
            if (await _unitOfWork.DepartamentoRepository.ExisteDepto(dto.NomeDepartamento, dto.SubDepartamento))
                throw new DepartamentoJaExisteException();

            var entity = await _unitOfWork.DepartamentoRepository.SelecionarPorId(id);
            entity = _mapper.Map(dto, entity);
            await _unitOfWork.DepartamentoRepository.Alterar(entity);
        }

        public async Task<IEnumerable<FuncionarioDepartamentoView>> ListarFuncDeptoAsync(Guid id)
        {
            var funcionarios = _unitOfWork.DepartamentoRepository.BuscarFuncDepto(id);
            var dtos = _mapper.Map<IEnumerable<FuncionarioDepartamentoView>>(funcionarios);
            foreach(var func in dtos)
            {
                func.Funcao = (await _unitOfWork.FuncaoRepository.SelecionarPorId(func.FuncaoId)).NomeFuncao;
                func.Departamento = _mapper.Map<DepartamentoViewDtoResult>(await _unitOfWork.DepartamentoRepository.SelecionarPorId(func.DepartamentoId));
            }

            return dtos;
        }
    }
}
