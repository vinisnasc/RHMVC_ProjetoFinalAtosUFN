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
    public class DecimoTerceiroRepository : BaseRepository<DecimoTerceiro>, IDecimoTerceiroRepository
    {
        public DecimoTerceiroRepository(RhContext context) : base(context)
        {
        }
    }
}
