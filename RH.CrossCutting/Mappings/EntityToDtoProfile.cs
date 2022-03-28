using AutoMapper;
using RH.Domain.Dtos.Views;
using RH.Domain.Entities;
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