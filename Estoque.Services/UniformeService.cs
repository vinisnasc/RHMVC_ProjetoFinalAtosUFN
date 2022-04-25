using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Repository;
using Estoque.Domain.Interfaces.Services;

namespace Estoque.Services
{
    public class UniformeService : IUniformeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UniformeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UniformeDto>> BuscarTodos()
        {
            var entities = await _unitOfWork.UniformeRepository.SelecionarTudo();
            var dtos = _mapper.Map<List<UniformeDto>>(entities);
            return dtos.ToList();
        }

        public async Task<UniformeDto> Cadastrar(UniformeCadastroDto dto)
        {
            var entity = _mapper.Map<Uniforme>(dto);
            entity.Id = Guid.NewGuid();
            await _unitOfWork.UniformeRepository.Incluir(entity);
            return _mapper.Map<UniformeDto>(entity);
        }
    }
}