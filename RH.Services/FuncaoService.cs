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

        public async Task CadastrarAsync(FuncaoCadastroDto dto)
        {
            if (await _unitOfWork.FuncaoRepository.ExisteFuncao(dto.NomeFuncao))
                throw new FuncaoJaExisteException();

            var entity = _mapper.Map<Funcao>(dto);
            await _unitOfWork.FuncaoRepository.Incluir(entity);
        }
    }
}
