using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;
using Estoque.Domain.Interfaces.Repository;
using Estoque.Domain.Interfaces.Services;

namespace Estoque.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IMapper _mapper;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IMapper mapper)
        {
            _funcionarioRepository = funcionarioRepository;
            _mapper = mapper;
        }

        public List<FuncionarioDto> BuscarTodos()
        {
            var entities = _funcionarioRepository.SelecionarTudo();
            var dtos = _mapper.Map<List<FuncionarioDto>>(entities);
            return dtos;
        }

        public FuncionarioDto CadastrarFuncionario(FuncionarioDto dto)
        {
            var entity = _mapper.Map<Funcionario>(dto);
            entity = _funcionarioRepository.Incluir(entity);
            return _mapper.Map<FuncionarioDto>(entity);
        }

        public FuncionarioDto FindById(Guid id)
        {
            var entity = _funcionarioRepository.SelecionarPorId(id);
            return _mapper.Map<FuncionarioDto>(entity);
        }
    }
}
