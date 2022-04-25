using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;
using Estoque.Domain.Dto.Messages;

namespace RH.CrossCutting.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            // Epi
            CreateMap<EpiDto, Epi>();
            CreateMap<EpiCadastrarDto, Epi>();

            // Uniforme
            CreateMap<UniformeCadastroDto, Uniforme>();

            // Almoxarifado
            CreateMap<AlmoxarifadoCadastroDto, Almoxarifado>();
            CreateMap<AlmoxarifadoUpdateDto, Almoxarifado>();

            // Funcionario
            CreateMap<FuncionarioDto, Funcionario>();
            CreateMap<AdmissaoDto, Funcionario>();
        }
    }
}
