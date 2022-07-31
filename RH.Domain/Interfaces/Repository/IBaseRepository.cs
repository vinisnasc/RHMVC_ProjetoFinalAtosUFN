using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
            Task Incluir(T entity);
            Task Alterar(T entity);
            Task<T> SelecionarPorId(Guid id);
            Task<List<T>> SelecionarTudo();
    }
}