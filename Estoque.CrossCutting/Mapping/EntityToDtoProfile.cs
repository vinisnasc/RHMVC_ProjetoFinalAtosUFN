using AutoMapper;
using Estoque.Domain;
using Estoque.Domain.Dto;
using Estoque.Domain.Dto.Messages;

namespace RH.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            // Epi
            CreateMap<Epi, EpiDto>();

            // Uniforme
            CreateMap<Uniforme, UniformeDto>();

            // Almoxarifado
            CreateMap<Almoxarifado, AlmoxarifadoDto>();

            // Funcionario
            CreateMap<Funcionario, FuncionarioDto>();
        }
    }
}