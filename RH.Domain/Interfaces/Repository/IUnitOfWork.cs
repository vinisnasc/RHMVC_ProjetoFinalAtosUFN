using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IFuncaoRepository FuncaoRepository { get; }
        public IEnderecoRepository EnderecoRepository { get; set; }
        public IContaBancariaRepository ContaBancariaRepository { get; set; }
        public IMunicipioRepository MunicipioRepository { get; set; }
        public IUfRepository UfRepository { get; set; }
        public IDepartamentoRepository DepartamentoRepository { get; set; }
        public IDecimoTerceiroRepository DecimoTerceiroRepository { get; set; }
        public IFeriasRepository FeriasRepository { get; set; }
        public IPagamentoRepository PagamentoRepository { get; set; }
    }
}
