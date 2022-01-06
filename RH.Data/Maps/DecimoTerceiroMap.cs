using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Data.Maps
{
    public class DecimoTerceiroMap : IEntityTypeConfiguration<DecimoTerceiro>
    {
        public void Configure(EntityTypeBuilder<DecimoTerceiro> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(f => f.Funcionario)
                .WithMany(d => d.DecimoTerceiro)
                .HasForeignKey(f => f.FuncionarioId);  
        }
    }
}
