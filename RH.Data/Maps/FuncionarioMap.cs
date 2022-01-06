using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RH.Domain.Entities;

namespace RH.Data.Maps
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Registro);

            builder.HasOne(e => e.Endereco)
                   .WithMany(f => f.Funcionarios)
                   .HasForeignKey(k => k.EnderecoId);

            builder.HasOne(b => b.ContaBancaria)
                  .WithMany(f => f.Funcionarios)
                  .HasForeignKey(c => c.ContaBancariaId);

            builder.HasOne(d => d.Departamento)
               .WithMany(f => f.Funcionarios)
               .HasForeignKey(k => k.DepartamentoId);

            builder.HasOne(f => f.Funcao)
                .WithMany(f => f.Funcionarios)
                .HasForeignKey(k => k.FuncaoId);
        }
    }
}
