using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Repository;
using Estoque.Domain.Interfaces.Services;

namespace Estoque.Services
{
    public class EpiService : IEpiService
    {
        private readonly IEpiRepository _epiRepository;
        private readonly IMapper _mapper;

        public EpiService(IEpiRepository epiRepository, IMapper mapper)
        {
            _epiRepository = epiRepository;
            _mapper = mapper;
        }

        public List<EpiDto> BuscarTodos()
        {
            var entities = _epiRepository.SelecionarTudo();
            var dtos = _mapper.Map<List<EpiDto>>(entities);
            return dtos.ToList();
        }

        /*
        public async Task<EpiDto> CadastrarAsync(EpiCadastrarDto dto)
        {
            var entity = _mapper.Map<Epi>(dto);
            await _epiRepository.Incluir(entity);
            return _mapper.Map<EpiDto>(entity);
        }*/
    }
}