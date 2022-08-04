using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.Domain.Entities;

namespace RH.Data.Maps
{
    public class PagamentoMap : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.ToTable("Pagamentos");

            builder.HasKey(x => x.Id);

            builder.HasOne(f => f.Funcionario)
                .WithMany(d => d.Pagamentos)
                .HasForeignKey(f => f.FuncionarioId);
        }
    }
}