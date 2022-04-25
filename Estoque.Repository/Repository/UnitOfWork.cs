using Estoque.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFuncionarioRepository FuncionarioRepository { get; }
        public IAlmoxarifadoRepository AlmoxarifadoRepository { get; }
        public IEpiRepository EpiRepository { get; }
        public IUniformeRepository UniformeRepository { get; }

        public UnitOfWork()
        {
            FuncionarioRepository = new FuncionarioRepository();
            AlmoxarifadoRepository = new AlmoxarifadoRepository();
            UniformeRepository = new UniformeRepository();
            EpiRepository = new EpiRepository();
        }
    }
}
