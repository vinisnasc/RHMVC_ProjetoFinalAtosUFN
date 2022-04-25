using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Repository;
using Estoque.Domain.Interfaces.Services;

namespace Estoque.Services
{
    public class EpiService : IEpiService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EpiService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EpiDto>> BuscarTodos()
        {
            var entities = await _unitOfWork.EpiRepository.SelecionarTudo();
            var dtos = _mapper.Map<List<EpiDto>>(entities);
            return dtos.ToList();
        }

        public async Task<EpiDto> Cadastrar(EpiCadastrarDto dto)
        {
            var entity = _mapper.Map<Epi>(dto);
            entity.Id = Guid.NewGuid();
            await _unitOfWork.EpiRepository.Incluir(entity);
            return _mapper.Map<EpiDto>(entity);
        }
    }
}