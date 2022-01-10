using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Data.Migrations
{
    public partial class CorrecaoNaDemissao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "Id",
                keyValue: new Guid("d635e914-e0fe-4c33-b118-7d6d868c3dc5"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DemissaoId",
                table: "Funcionario",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "ContaBancaria",
                keyColumn: "Id",
                keyValue: new Guid("07a49006-1a80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7349));

            migrationBuilder.UpdateData(
                table: "Departamento",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7302));

            migrationBuilder.UpdateData(
                table: "Endereco",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7253));

            migrationBuilder.UpdateData(
                table: "Funcao",
                keyColumn: "Id",
                keyValue: new Guid("07b49006-1b80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7326));

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "Id", "Admissao", "Ativo", "CPF", "ContaBancariaId", "CreateAt", "DataDemissao", "DemissaoId", "DepartamentoId", "Email", "EnderecoId", "FuncaoId", "Nome", "NomeSocial", "RG", "Registro", "Sexo", "UpdateAt" },
                values: new object[] { new Guid("0a8868bb-5a23-41f5-ba2e-86887c46b575"), new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7406), true, "44444444444", new Guid("07a49006-1a80-4784-9de9-f535050e1aad"), new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7405), null, null, new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"), "vini.souza00@gmail.com", new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"), new Guid("07b49006-1b80-4784-9de9-f535050e1aad"), "Vinicius Nascimento", "N/A", "333333333", 1, 1, null });

            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "Id",
                keyValue: new Guid("f0a1a069-3db3-4f31-b71d-20074e3b861b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7036));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7055));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("20792100-80af-49a8-8195-f7c36441c38d"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("275002db-aa62-444e-a179-b801583c3568"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7016));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b72bc3f-4613-4313-963c-9621db443e32"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7052));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7067));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7026));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 15, 50, 32, 987, DateTimeKind.Utc).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7069));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7024));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7057));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7038));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7059));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7050));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 9, 12, 50, 32, 987, DateTimeKind.Local).AddTicks(7040));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "Id",
                keyValue: new Guid("0a8868bb-5a23-41f5-ba2e-86887c46b575"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DemissaoId",
                table: "Funcionario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
        }
    }
}
