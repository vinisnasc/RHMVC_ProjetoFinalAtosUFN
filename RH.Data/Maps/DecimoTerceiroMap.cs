using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.Domain.Entities;

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