using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IMunicipioRepository : IBaseRepository<Municipio>
    {
        Task<Municipio> BuscarPorNomeUfAsync(string nome, Guid ufId);
    }
}