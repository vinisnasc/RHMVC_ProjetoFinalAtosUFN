using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;

namespace RH.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            // Epi
            CreateMap<Epi, EpiDto>();

            // Funcionario
            CreateMap<Funcionario, FuncionarioDto>();
        }
    }
}