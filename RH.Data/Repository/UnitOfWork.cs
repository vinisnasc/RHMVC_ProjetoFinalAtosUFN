using RH.Data.Contexto;
using RH.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RhContext _context;
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IEnderecoRepository EnderecoRepository { get; set; }
        public IContaBancariaRepository ContaBancariaRepository { get; set; }
        public IMunicipioRepository MunicipioRepository { get; set; }
        public IUfRepository UfRepository { get; set; }
        public IDepartamentoRepository DepartamentoRepository { get; set; }
        public IFuncaoRepository FuncaoRepository { get; set; }
        public IDecimoTerceiroRepository DecimoTerceiroRepository { get; set; }
        public IFeriasRepository FeriasRepository { get; set; }
        public IPagamentoRepository PagamentoRepository { get; set; }

        public UnitOfWork(RhContext context)
        {
            _context = context;
            FuncionarioRepository = new FuncionarioRepository(context);
            EnderecoRepository = new EnderecoRepository(context);
            ContaBancariaRepository = new ContaBancariaRepository(context);
            MunicipioRepository = new MunicipioRepository(context);
            UfRepository = new UfRepository(context);
            DepartamentoRepository = new DepartamentoRepository(context);
            FuncaoRepository = new FuncaoRepository(context);
            DecimoTerceiroRepository = new DecimoTerceiroRepository(context);
            FeriasRepository = new FeriasRepository(context);
            PagamentoRepository = new PagamentoRepository(context);
        }
    }
}
