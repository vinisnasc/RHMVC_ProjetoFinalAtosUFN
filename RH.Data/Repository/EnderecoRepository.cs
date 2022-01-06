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
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly RhContext _context;
        public EnderecoRepository(RhContext contexto) : base(contexto)
        {
            _context = contexto;
        }

        public async Task<Endereco> ProcurarEndereco(string cep, int num, string compl)
        {
            return await _context.Endereco.FirstOrDefaultAsync(x => x.Cep == cep && x.Complemento == compl && x.Numero == num);
        }

        public override Task Incluir(Endereco entity)
        {
            return base.Incluir(entity);
        }
    }
}
