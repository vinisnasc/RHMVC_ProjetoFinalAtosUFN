using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IDemissaoRepository : IBaseRepository<Demissao>
    {
        Task<bool> ExistePagamentoDemissaoAsync(Guid id);
    }
}
