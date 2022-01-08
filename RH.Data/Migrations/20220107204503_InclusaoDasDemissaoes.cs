using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Data.Migrations
{
    public partial class InclusaoDasDemissaoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "Id",
                keyValue: new Guid("165b42e2-18e1-430f-8ca3-16c124cdc0c0"));

            migrationBuilder.RenameColumn(
                name: "Demissao",
                table: "Funcionario",
                newName: "DataDemissao");

            migrationBuilder.AddColumn<Guid>(
                name: "DemissaoId",
                table: "Funcionario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Demissao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorMes = table.Column<double>(type: "float", nullable: false),
                    ValorDecimo = table.Column<double>(type: "float", nullable: false),
                    ValorFerias = table.Column<double>(type: "float", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Demissao_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ContaBancaria",
                keyColumn: "Id",
                keyValue: new Guid("07a49006-1a80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(2328));

            migrationBuilder.UpdateData(
                table: "Departamento",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "Endereco",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Funcao",
                keyColumn: "Id",
                keyValue: new Guid("07b49006-1b80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(2289));

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "Id", "Admissao", "Ativo", "CPF", "ContaBancariaId", "CreateAt", "DataDemissao", "DemissaoId", "DepartamentoId", "Email", "EnderecoId", "FuncaoId", "Nome", "NomeSocial", "RG", "Registro", "Sexo", "UpdateAt" },
                values: new object[] { new Guid("d635e914-e0fe-4c33-b118-7d6d868c3dc5"), new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(2399), true, "44444444444", new Guid("07a49006-1a80-4784-9de9-f535050e1aad"), new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(2398), null, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"), "vini.souza00@gmail.com", new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"), new Guid("07b49006-1b80-4784-9de9-f535050e1aad"), "Vinicius Nascimento", "N/A", "333333333", 1, 1, null });

            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "Id",
                keyValue: new Guid("f0a1a069-3db3-4f31-b71d-20074e3b861b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(2147));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1905));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("20792100-80af-49a8-8195-f7c36441c38d"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1831));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("275002db-aa62-444e-a179-b801583c3568"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1865));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1820));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b72bc3f-4613-4313-963c-9621db443e32"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1848));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1811));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1894));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1897));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1837));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 20, 45, 2, 143, DateTimeKind.Utc).AddTicks(1784));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1842));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1795));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1855));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1889));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 7, 17, 45, 2, 143, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.CreateIndex(
                name: "IX_Demissao_FuncionarioId",
                table: "Demissao",
                column: "FuncionarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demissao");

            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "Id",
                keyValue: new Guid("d635e914-e0fe-4c33-b118-7d6d868c3dc5"));

            migrationBuilder.DropColumn(
                name: "DemissaoId",
                table: "Funcionario");

            migrationBuilder.RenameColumn(
                name: "DataDemissao",
                table: "Funcionario",
                newName: "Demissao");

            migrationBuilder.UpdateData(
                table: "ContaBancaria",
                keyColumn: "Id",
                keyValue: new Guid("07a49006-1a80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5336));

            migrationBuilder.UpdateData(
                table: "Departamento",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5289));

            migrationBuilder.UpdateData(
                table: "Endereco",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "Funcao",
                keyColumn: "Id",
                keyValue: new Guid("07b49006-1b80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5312));

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "Id", "Admissao", "Ativo", "CPF", "ContaBancariaId", "CreateAt", "Demissao", "DepartamentoId", "Email", "EnderecoId", "FuncaoId", "Nome", "NomeSocial", "RG", "Registro", "Sexo", "UpdateAt" },
                values: new object[] { new Guid("165b42e2-18e1-430f-8ca3-16c124cdc0c0"), new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5394), true, "44444444444", new Guid("07a49006-1a80-4784-9de9-f535050e1aad"), new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5393), null, new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"), "vini.souza00@gmail.com", new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"), new Guid("07b49006-1b80-4784-9de9-f535050e1aad"), "Vinicius Nascimento", "N/A", "333333333", 1, 1, null });

            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "Id",
                keyValue: new Guid("f0a1a069-3db3-4f31-b71d-20074e3b861b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5209));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5040));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5056));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5069));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("20792100-80af-49a8-8195-f7c36441c38d"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("275002db-aa62-444e-a179-b801583c3568"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5048));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5020));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5025));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5023));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b72bc3f-4613-4313-963c-9621db443e32"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5038));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5046));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5063));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5065));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5032));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 19, 14, 6, 863, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5030));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5058));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5042));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 6, 16, 14, 6, 863, DateTimeKind.Local).AddTicks(5044));
        }
    }
}
