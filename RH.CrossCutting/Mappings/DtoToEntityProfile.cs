using AutoMapper;
using RH.Domain.Dtos.Input;
using RH.Domain.Dtos.Responses;
using RH.Domain.Entities;
using System.Text.RegularExpressions;

namespace RH.CrossCutting.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            // Funcionario
            CreateMap<FuncionarioCadastroDto, Funcionario>().ReverseMap();
            CreateMap<FuncionarioCadastroDto, Endereco>();
            CreateMap<Endereco, FuncionarioCadastroDto>();
            CreateMap<FuncionarioCadastroDto, Municipio>().ReverseMap();
            CreateMap<FuncionarioEditarDadosPessoaisDto, Funcionario>();

            CreateMap<EnderecoDTO, Endereco>().ReverseMap();
            CreateMap<UfDTO, Uf>().ReverseMap();
            CreateMap<MunicipioDTO, Municipio>().ReverseMap();

            // Conta Bancaria
            CreateMap<FuncionarioCadastroDto, ContaBancaria>();

            // Cep
            CreateMap<CepResponse, Endereco>()
                .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Logradouro));
            CreateMap<CepResponse, Municipio>()
                .ForMember(dest => dest.NomeMunicipio, opt => opt.MapFrom(src => src.Localidade))
                .ForMember(dest => dest.Uf, opt => opt.Ignore());

            // Funcao
            CreateMap<FuncaoCadastroDto, Funcao>()
                .ForMember(dest => dest.NomeFuncao, opt => opt.MapFrom(
                           src => Regex.Replace(src.NomeFuncao.ToUpper().Trim(), @"\s+", " ")))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<FuncaoEditarDto, Funcao>()
                .ForMember(dest => dest.NomeFuncao, opt => opt.MapFrom(
                           src => Regex.Replace(src.NomeFuncao.ToUpper().Trim(), @"\s+", " ")))
                .ForMember(dest => dest.UpdateAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
                .ForMember(dest => dest.Salario, opt => opt.Ignore());

            // Departamento
            CreateMap<DepartamentoCadastroDto, Departamento>()
                .ForMember(dest => dest.NomeDepartamento, opt => opt.MapFrom(
                           src => Regex.Replace(src.NomeDepartamento.ToUpper().Trim(), @"\s+", " ")))
                .ForMember(dest => dest.SubDepartamento, opt => opt.MapFrom(
                           src => Regex.Replace(src.SubDepartamento.ToUpper().Trim(), @"\s+", " ")))
                .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<DepartamentoEditarDto, Departamento>()
                .ForMember(dest => dest.NomeDepartamento, opt => opt.MapFrom(
                           src => Regex.Replace(src.NomeDepartamento.ToUpper().Trim(), @"\s+", " ")))
                .ForMember(dest => dest.SubDepartamento, opt => opt.MapFrom(
                           src => Regex.Replace(src.SubDepartamento.ToUpper().Trim(), @"\s+", " ")))
                .ForMember(dest => dest.UpdateAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
