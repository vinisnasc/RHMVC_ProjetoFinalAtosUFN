using Microsoft.EntityFrameworkCore;
using RH.Data.Contexto;
using RH.Domain.Entities;
using RH.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Data.Repository
{
    public class DepartamentoRepository : BaseRepository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(RhContext context) : base(context)
        {}

        public async Task<int> QuantidadeFuncionarioAsync(Guid id)
        {
            return await _context.Funcionario.CountAsync(x => x.DepartamentoId == id);
        }

        public IEnumerable<Funcionario> BuscarFuncDepto(Guid id)
        {
            return  _context.Funcionario.Where(x => x.DepartamentoId == id);
        }

        public async Task<bool> ExisteDepto(string depto, string subdepto)
        {
            return await _context.Departamento.AnyAsync(x => x.NomeDepartamento == depto && x.SubDepartamento == subdepto);
        }
    }
}
