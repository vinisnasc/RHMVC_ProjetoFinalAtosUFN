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
    internal class FeriasMap : IEntityTypeConfiguration<Ferias>
    {
        public void Configure(EntityTypeBuilder<Ferias> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(f => f.Funcionario)
                .WithMany(d => d.Ferias)
                .HasForeignKey(f => f.FuncionarioId);
        }
    }
}