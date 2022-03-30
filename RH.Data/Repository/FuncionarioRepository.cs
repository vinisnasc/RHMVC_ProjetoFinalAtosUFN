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

        public override async Task<Funcionario> SelecionarPorId(Guid id)
        {
            return await _context.Funcionario.Include(x => x.Departamento)
                                             .Include(x => x.Funcao)
                                             .Include(x => x.ContaBancaria)
                                             .Include(x => x.Endereco)
                                             .ThenInclude(x => x.Municipio)
                                             .ThenInclude(x => x.Uf)
                                             .FirstAsync(x => x.Id == id);
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

        public async Task<Funcionario> BuscarPorEmailAsync(string email)
        {
            return await _context.Funcionario.Include(x => x.Departamento).FirstOrDefaultAsync(x => x.Email == email && x.Ativo == true);
        }
    }
}
