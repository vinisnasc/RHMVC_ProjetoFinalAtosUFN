using AutoMapper;
using WEBAPP.MVC.Modulos.RecursosHumanos.Models;
using WEBAPP.MVC.Modulos.RecursosHumanos.Models.InputModel;

namespace WEBAPP.MVC.Configs
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FuncionarioModel, FuncionarioUpdate>().ReverseMap();
        }
    }
}