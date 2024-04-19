using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RH.Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaBancaria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Banco = table.Column<int>(type: "int", nullable: false),
                    Agencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContaCorrente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaBancaria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDepartamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFuncao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ufs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ufs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeMunicipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Ufs_UfId",
                        column: x => x.UfId,
                        principalTable: "Ufs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Registro = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admissao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    DataDemissao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DemissaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContaBancariaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_ContaBancaria_ContaBancariaId",
                        column: x => x.ContaBancariaId,
                        principalTable: "ContaBancaria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Funcoes_FuncaoId",
                        column: x => x.FuncaoId,
                        principalTable: "Funcoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DecimoTerceiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecimoTerceiro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecimoTerceiro_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_Demissao_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ferias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ferias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ferias_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagamentos_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ContaBancaria",
                columns: new[] { "Id", "Agencia", "Banco", "ContaCorrente", "CreateAt", "UpdateAt" },
                values: new object[] { new Guid("07a49006-1a80-4784-9de9-f535050e1aad"), "1212-2", 33, "19191-8", new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(2280), null });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "CreateAt", "NomeDepartamento", "SubDepartamento", "UpdateAt" },
                values: new object[] { new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(2186), "PRESIDENCIA", "ADMINISTRACAO", null });

            migrationBuilder.InsertData(
                table: "Funcoes",
                columns: new[] { "Id", "CreateAt", "NomeFuncao", "Salario", "UpdateAt" },
                values: new object[] { new Guid("07b49006-1b80-4784-9de9-f535050e1aad"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(2233), "ADMINISTRADOR", 5000.0, null });

            migrationBuilder.InsertData(
                table: "Ufs",
                columns: new[] { "Id", "CreateAt", "Nome", "Sigla", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1657), "Para", "PA", null },
                    { new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1683), "Rondonia", "RO", null },
                    { new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1705), "Distrito Federal", "DF", null },
                    { new Guid("20792100-80af-49a8-8195-f7c36441c38d"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1636), "Espirito Santo", "ES", null },
                    { new Guid("275002db-aa62-444e-a179-b801583c3568"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1671), "Piaui", "PI", null },
                    { new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1626), "Amazonas", "AM", null },
                    { new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1633), "Ceara", "CE", null },
                    { new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1629), "Bahia", "BA", null },
                    { new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1674), "Rio de Janeiro", "RJ", null },
                    { new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1654), "Minas Gerais", "MG", null },
                    { new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1667), "Pernambuco", "PE", null },
                    { new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1622), "Amapa", "AP", null },
                    { new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1695), "Sao Paulo", "SP", null },
                    { new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1681), "Rio Grande do Sul", "RS", null },
                    { new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1698), "Sergipe", "SE", null },
                    { new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1642), "Maranhao", "MA", null },
                    { new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), new DateTime(2024, 4, 19, 1, 16, 57, 315, DateTimeKind.Utc).AddTicks(1596), "Acre", "AC", null },
                    { new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1646), "Mato Grosso", "MT", null },
                    { new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1701), "Tocantins", "TO", null },
                    { new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1639), "Goias", "GO", null },
                    { new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1609), "Alagoas", "AL", null },
                    { new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1687), "Roraima", "RR", null },
                    { new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1650), "Mato Grosso do Sul", "MS", null },
                    { new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1661), "Paraiba", "PB", null },
                    { new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1689), "Santa Catarina", "SC", null },
                    { new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1677), "Rio Grande do Norte", "RN", null },
                    { new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(1664), "Parana", "PR", null }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "CreateAt", "NomeMunicipio", "UfId", "UpdateAt" },
                values: new object[] { new Guid("f0a1a069-3db3-4f31-b71d-20074e3b861b"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(2035), "São Paulo", new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), null });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "Id", "Cep", "Complemento", "CreateAt", "MunicipioId", "Numero", "Rua", "UpdateAt" },
                values: new object[] { new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"), "03579240", null, new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(2088), new Guid("f0a1a069-3db3-4f31-b71d-20074e3b861b"), 1934, "Rua Machado de Castro", null });

            migrationBuilder.InsertData(
                table: "Funcionarios",
                columns: new[] { "Id", "Admissao", "Ativo", "CPF", "ContaBancariaId", "CreateAt", "DataDemissao", "DataNascimento", "DemissaoId", "DepartamentoId", "Email", "EnderecoId", "FotoPerfil", "FuncaoId", "Nome", "NomeSocial", "RG", "Registro", "Sexo", "UpdateAt" },
                values: new object[] { new Guid("e5b9f7f7-4f21-488f-b0e4-5290580486fa"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(2495), true, "44444444444", new Guid("07a49006-1a80-4784-9de9-f535050e1aad"), new DateTime(2024, 4, 18, 22, 16, 57, 315, DateTimeKind.Local).AddTicks(2493), null, new DateTime(1994, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"), "vini.souza00@gmail.com", new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"), null, new Guid("07b49006-1b80-4784-9de9-f535050e1aad"), "Vinicius Nascimento", "N/A", "333333333", 1, 1, null });

            migrationBuilder.CreateIndex(
                name: "IX_DecimoTerceiro_FuncionarioId",
                table: "DecimoTerceiro",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Demissao_FuncionarioId",
                table: "Demissao",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_MunicipioId",
                table: "Enderecos",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ferias_FuncionarioId",
                table: "Ferias",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_ContaBancariaId",
                table: "Funcionarios",
                column: "ContaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EnderecoId",
                table: "Funcionarios",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_FuncaoId",
                table: "Funcionarios",
                column: "FuncaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Registro",
                table: "Funcionarios",
                column: "Registro");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_UfId",
                table: "Municipios",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagamentos_FuncionarioId",
                table: "Pagamentos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ufs_Sigla",
                table: "Ufs",
                column: "Sigla",
                unique: true,
                filter: "[Sigla] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecimoTerceiro");

            migrationBuilder.DropTable(
                name: "Demissao");

            migrationBuilder.DropTable(
                name: "Ferias");

            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "ContaBancaria");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Funcoes");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Ufs");
        }
    }
}
