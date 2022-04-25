using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Repository;
using Estoque.Domain.Interfaces.Services;

namespace Estoque.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FuncionarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<FuncionarioDto>> BuscarTodos()
        {
            var entities = await _unitOfWork.FuncionarioRepository.SelecionarTudo();
            var dtos = _mapper.Map<List<FuncionarioDto>>(entities);
            return dtos;
        }

        public async Task<FuncionarioDto> CadastrarFuncionario(FuncionarioDto dto)
        {
            var entity = _mapper.Map<Funcionario>(dto);
            entity = await _unitOfWork.FuncionarioRepository.Incluir(entity);
            return _mapper.Map<FuncionarioDto>(entity);
        }

        public async Task<FuncionarioDto> FindById(Guid id)
        {
            var entity = await _unitOfWork.FuncionarioRepository.SelecionarPorId(id);
            return _mapper.Map<FuncionarioDto>(entity);
        }
    }
}
