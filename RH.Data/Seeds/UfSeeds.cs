using Microsoft.EntityFrameworkCore;
using RH.Domain.Entities;

namespace RH.Data
{
    public static class UfSeeds
    {
        public static void UfSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uf>().HasData(
                new Uf()
                {
                    Id = new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"),
                    Sigla = "AC",
                    Nome = "Acre",
                    CreateAt = DateTime.UtcNow
                },
                new Uf()
                {
                    Id = new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"),
                    Sigla = "AL",
                    Nome = "Alagoas",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"),
                    Sigla = "AP",
                    Nome = "Amapa",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"),
                    Sigla = "AM",
                    Nome = "Amazonas",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"),
                    Sigla = "BA",
                    Nome = "Bahia",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"),
                    Sigla = "CE",
                    Nome = "Ceara",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("20792100-80af-49a8-8195-f7c36441c38d"),
                    Sigla = "ES",
                    Nome = "Espirito Santo",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"),
                    Sigla = "GO",
                    Nome = "Goias",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"),
                    Sigla = "MA",
                    Nome = "Maranhao",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"),
                    Sigla = "MT",
                    Nome = "Mato Grosso",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"),
                    Sigla = "MS",
                    Nome = "Mato Grosso do Sul",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("3b72bc3f-4613-4313-963c-9621db443e32"),
                    Sigla = "MG",
                    Nome = "Minas Gerais",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"),
                    Sigla = "PA",
                    Nome = "Para",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"),
                    Sigla = "PB",
                    Nome = "Paraiba",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"),
                    Sigla = "PR",
                    Nome = "Parana",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"),
                    Sigla = "PE",
                    Nome = "Pernambuco",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("275002db-aa62-444e-a179-b801583c3568"),
                    Sigla = "PI",
                    Nome = "Piaui",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"),
                    Sigla = "RJ",
                    Nome = "Rio de Janeiro",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"),
                    Sigla = "RN",
                    Nome = "Rio Grande do Norte",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"),
                    Sigla = "RS",
                    Nome = "Rio Grande do Sul",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"),
                    Sigla = "RO",
                    Nome = "Rondonia",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"),
                    Sigla = "RR",
                    Nome = "Roraima",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"),
                    Sigla = "SC",
                    Nome = "Santa Catarina",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"),
                    Sigla = "SP",
                    Nome = "Sao Paulo",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"),
                    Sigla = "SE",
                    Nome = "Sergipe",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"),
                    Sigla = "TO",
                    Nome = "Tocantins",
                    CreateAt = DateTime.Now
                },
                new Uf()
                {
                    Id = new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"),
                    Sigla = "DF",
                    Nome = "Distrito Federal",
                    CreateAt = DateTime.Now
                });
        }
    }
}