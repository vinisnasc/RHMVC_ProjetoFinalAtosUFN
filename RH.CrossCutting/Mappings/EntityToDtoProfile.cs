using AutoMapper;
using RH.Domain.Dtos.Views;
using RH.Domain.Entities;
using RH.Domain.Menssagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            // Funcionarios
            CreateMap<Funcionario, FuncionarioViewDtoResult>();
            CreateMap<Funcionario, FuncionarioDepartamentoView>();
            CreateMap<Funcionario, FuncionarioFuncaoView>();
            CreateMap<Funcionario, AdmissaoMessage>().ForMember(dest => dest.Funcao, opt => opt.MapFrom(src => src.Funcao.NomeFuncao))
                                                 .ForMember(dest => dest.Departamento, opt => opt.MapFrom(src => src.Departamento));

            // Departamentos
            CreateMap<Departamento, DepartamentoViewDtoResult>();

            // Funcoes
            CreateMap<Funcao, FuncaoViewDtoResult>();

            // Endereço
            CreateMap<Endereco, EnderecoViewResult>();
            CreateMap<Municipio, MunicipioViewResult>();
            CreateMap<Uf, UfViewResult>();

            // ContaBancaria
            CreateMap<ContaBancaria, ContaBancariaViewResult>();
        }
    }
}