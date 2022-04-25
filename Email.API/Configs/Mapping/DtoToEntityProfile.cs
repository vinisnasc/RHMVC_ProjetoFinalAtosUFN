using AutoMapper;
using Email.API.Domain.DTOs.Messages;
using Email.API.Domain.Entities;
using Email.Domain.Configs;

namespace Email.API.Configs.Mapping
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<AdmissaoMessage, EmailLog>().ReverseMap();
            CreateMap<AdmissaoMessage, Message>().ReverseMap();
        }
    }
}
