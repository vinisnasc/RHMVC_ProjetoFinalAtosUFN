using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;

namespace RH.CrossCutting.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            // Epi
            CreateMap<EpiDto, Epi>();
            CreateMap<EpiCadastrarDto, Epi>();

            // Funcionario
            CreateMap<FuncionarioDto, Funcionario>();
        }
    }
}
