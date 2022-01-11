using Microsoft.EntityFrameworkCore;
using RH.Domain.Entities;
using System.Reflection;

namespace RH.Data.Contexto
{
    public class RhContext : DbContext
    {
        public RhContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Uf> Uf { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<DecimoTerceiro> DecimoTerceiro { get; set; }
        public DbSet<Ferias> Ferias { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Demissao> Demissao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

            UfSeeds.UfSeed(modelBuilder);
            modelBuilder.Entity<Municipio>().HasData(new Municipio
            {
                Id = new Guid("f0a1a069-3db3-4f31-b71d-20074e3b861b"),
                NomeMunicipio = "São Paulo",
                UfId = Guid.Parse("5e684315-735e-4c8e-a508-8df50649dc1d"),
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Endereco>().HasData(new Endereco
            {
                Id = new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"),
                Cep = "03579240",
                Rua = "Rua Machado de Castro",
                MunicipioId = Guid.Parse("f0a1a069-3db3-4f31-b71d-20074e3b861b"),
                Numero = 1934,
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Departamento>().HasData(new Departamento
            {
                Id = new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"),
                NomeDepartamento = "Presidencia".ToUpper(),
                SubDepartamento = "Administracao".ToUpper(),
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Funcao>().HasData(new Funcao
            {
                Id = new Guid("07b49006-1b80-4784-9de9-f535050e1aad"),
                NomeFuncao = "Administrador".ToUpper(),
                Salario = 5000,
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<ContaBancaria>().HasData(new ContaBancaria
            {
                Id = new Guid("07a49006-1a80-4784-9de9-f535050e1aad"),
                Banco = 33,
                Agencia = "1212-2",
                ContaCorrente = "19191-8",
                CreateAt = DateTime.Now
            });
            modelBuilder.Entity<Funcionario>().HasData(new Funcionario
            {
                Id = Guid.NewGuid(),
                Registro = 1,
                Nome = "Vinicius Nascimento",
                NomeSocial = "N/A",
                Email = "vini.souza00@gmail.com",
                DataNascimento = new DateTime(1994, 04, 17),
                EnderecoId = Guid.Parse("fc73fc67-5137-4830-8f8c-425766ef4d6a"),
                CPF = "44444444444",
                RG = "333333333",
                Sexo = Domain.Enums.Genero.Masculino,
                CreateAt = DateTime.Now,
                Admissao = DateTime.Now,
                DepartamentoId = Guid.Parse("fc73fc67-5237-4830-8f8c-425766ef4d6a"),
                FuncaoId = Guid.Parse("07b49006-1b80-4784-9de9-f535050e1aad"),
                ContaBancariaId = Guid.Parse("07a49006-1a80-4784-9de9-f535050e1aad")
            });
        }
    }
}
