using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.Domain.Entities;

namespace RH.Data.Maps
{
    internal class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipios");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Uf).WithMany(x => x.Municipios).HasForeignKey(f => f.UfId);
        }
    }
}