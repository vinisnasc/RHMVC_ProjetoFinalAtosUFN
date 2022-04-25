using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IAlmoxarifadoRepository AlmoxarifadoRepository { get; }
        public IEpiRepository EpiRepository { get; }
        public IUniformeRepository UniformeRepository { get; }
    }
}
