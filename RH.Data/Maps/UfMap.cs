using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.Domain.Entities;

namespace RH.Data.Maps
{
    public class UfMap : IEntityTypeConfiguration<Uf>
    {
        public void Configure(EntityTypeBuilder<Uf> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasIndex(s => s.Sigla)
                   .IsUnique();
        }
    }
}