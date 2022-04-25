using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Repository;
using Estoque.Domain.Interfaces.Services;

namespace Estoque.Services
{
    public class AlmoxarifadoService : IAlmoxarifadoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlmoxarifadoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlmoxarifadoDto> BuscarPorId(Guid id)
        {
            var entity = await _unitOfWork.AlmoxarifadoRepository.SelecionarPorId(id);
            return _mapper.Map<AlmoxarifadoDto>(entity);
        }

        public async Task<List<AlmoxarifadoDto>> BuscarTodos()
        {
            var entities = await _unitOfWork.AlmoxarifadoRepository.SelecionarTudo();
            var dtos = _mapper.Map<List<AlmoxarifadoDto>>(entities);
            return dtos.ToList();
        }

        public async Task<AlmoxarifadoDto> Cadastrar(AlmoxarifadoCadastroDto dto)
        {
            var entity = _mapper.Map<Almoxarifado>(dto);
            entity.Id = Guid.NewGuid();
            await _unitOfWork.AlmoxarifadoRepository.Incluir(entity);
            return _mapper.Map<AlmoxarifadoDto>(entity);
        }

        public async Task<AlmoxarifadoDto> Alterar(AlmoxarifadoUpdateDto dto)
        {
            var entity = await _unitOfWork.AlmoxarifadoRepository.SelecionarPorId(dto.Id);
            entity = await _unitOfWork.AlmoxarifadoRepository.Alterar(_mapper.Map<Almoxarifado>(dto));
            return _mapper.Map<AlmoxarifadoDto>(entity);
        }
    }
}