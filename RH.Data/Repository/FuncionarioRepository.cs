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
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(RhContext contexto) : base(contexto)
        {}

        public override Task Incluir(Funcionario funcionario)
        {
            return base.Incluir(funcionario);
        }

        public async Task<Funcionario> ProcurarPorCpfAtivoAsync(string cpf)
        {
            return await _context.Funcionario.FirstOrDefaultAsync(x => x.CPF == cpf && x.DataDemissao == null);
        }

        public async Task<int> AtribuirNumeroDeRegistroAsync()
        {
            return (await _context.Funcionario.CountAsync()) + 1;
        }

        public List<Funcionario> BuscarTodosAtivos()
        {
            return _context.Funcionario.Where(x => x.Ativo == true).ToList();
        }
    }
}
