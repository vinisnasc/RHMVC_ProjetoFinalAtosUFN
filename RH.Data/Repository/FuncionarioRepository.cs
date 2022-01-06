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
        private readonly RhContext _context;
        public FuncionarioRepository(RhContext contexto) : base(contexto)
        {
            _context = contexto;
        }

        public override Task Incluir(Funcionario funcionario)
        {
            return base.Incluir(funcionario);
        }

        public async Task<Funcionario> ProcurarPorCpfAtivo(string cpf)
        {
            return await _context.Funcionario.FirstOrDefaultAsync(x => x.CPF == cpf && x.Demissao == null);
        }

        public async Task<int> AtribuirNumeroDeRegistro()
        {
            return (await _context.Funcionario.CountAsync()) + 1;
        }
    }
}
