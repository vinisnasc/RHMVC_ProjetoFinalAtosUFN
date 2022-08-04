using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.Domain.Entities;

namespace RH.Data.Maps
{
    public class DemissaoMap : IEntityTypeConfiguration<Demissao>
    {
        public void Configure(EntityTypeBuilder<Demissao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(f => f.Funcionario)
                 .WithOne(x => x.Demissao)
                 .HasForeignKey<Demissao>(x => x.FuncionarioId);
        }
    }
}