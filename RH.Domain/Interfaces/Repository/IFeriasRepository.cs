using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IFeriasRepository : IBaseRepository<Ferias>
    {
        Task<int> VerificarQuantidadeFeriasRecebidasAsync(Guid idFunc);
        Task<Ferias> BuscarFeriasData(DateTime dataPagamento, Guid id);
        Task<Ferias> BuscarFeriasMesAsync(DateTime data, Guid funcionarioid);
    }
}
