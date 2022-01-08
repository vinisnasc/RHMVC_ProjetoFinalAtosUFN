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
    public class DemissaoRepository : BaseRepository<Demissao>, IDemissaoRepository
    {
        public DemissaoRepository(RhContext context) : base(context)
        {}
    }
}
