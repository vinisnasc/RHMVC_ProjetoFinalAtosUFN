using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Data.Migrations
{
    public partial class fotoperfil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "Id",
                keyValue: new Guid("7140013e-f38a-465e-b49f-81347acf3227"));

            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ContaBancaria",
                keyColumn: "Id",
                keyValue: new Guid("07a49006-1a80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "Departamento",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "Endereco",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9800));

            migrationBuilder.UpdateData(
                table: "Funcao",
                keyColumn: "Id",
                keyValue: new Guid("07b49006-1b80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9915));

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "Id", "Admissao", "Ativo", "CPF", "ContaBancariaId", "CreateAt", "DataDemissao", "DataNascimento", "DemissaoId", "DepartamentoId", "Email", "EnderecoId", "FotoPerfil", "FuncaoId", "Nome", "NomeSocial", "RG", "Registro", "Sexo", "UpdateAt" },
                values: new object[] { new Guid("97315c5f-f155-4eb0-a73f-6210d87d3e13"), new DateTime(2022, 3, 4, 12, 9, 1, 845, DateTimeKind.Local).AddTicks(107), true, "44444444444", new Guid("07a49006-1a80-4784-9de9-f535050e1aad"), new DateTime(2022, 3, 4, 12, 9, 1, 845, DateTimeKind.Local).AddTicks(105), null, new DateTime(1994, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"), "vini.souza00@gmail.com", new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"), null, new Guid("07b49006-1b80-4784-9de9-f535050e1aad"), "Vinicius Nascimento", "N/A", "333333333", 1, 1, null });

            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "Id",
                keyValue: new Guid("f0a1a069-3db3-4f31-b71d-20074e3b861b"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9634));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9334));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("20792100-80af-49a8-8195-f7c36441c38d"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9310));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("275002db-aa62-444e-a179-b801583c3568"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9348));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9306));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9304));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9351));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b72bc3f-4613-4313-963c-9621db443e32"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9331));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9344));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9296));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9371));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9317));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 15, 9, 1, 844, DateTimeKind.Utc).AddTicks(9268));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9364));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9327));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"),
                column: "CreateAt",
                value: new DateTime(2022, 3, 4, 12, 9, 1, 844, DateTimeKind.Local).AddTicks(9341));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Funcionario",
                keyColumn: "Id",
                keyValue: new Guid("97315c5f-f155-4eb0-a73f-6210d87d3e13"));

            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Funcionario");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ContaBancaria",
                keyColumn: "Id",
                keyValue: new Guid("07a49006-1a80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "Departamento",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6571));

            migrationBuilder.UpdateData(
                table: "Endereco",
                keyColumn: "Id",
                keyValue: new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6517));

            migrationBuilder.UpdateData(
                table: "Funcao",
                keyColumn: "Id",
                keyValue: new Guid("07b49006-1b80-4784-9de9-f535050e1aad"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6612));

            migrationBuilder.InsertData(
                table: "Funcionario",
                columns: new[] { "Id", "Admissao", "Ativo", "CPF", "ContaBancariaId", "CreateAt", "DataDemissao", "DataNascimento", "DemissaoId", "DepartamentoId", "Email", "EnderecoId", "FuncaoId", "Nome", "NomeSocial", "RG", "Registro", "Sexo", "UpdateAt" },
                values: new object[] { new Guid("7140013e-f38a-465e-b49f-81347acf3227"), new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6755), true, "44444444444", new Guid("07a49006-1a80-4784-9de9-f535050e1aad"), new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6754), null, new DateTime(1994, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("fc73fc67-5237-4830-8f8c-425766ef4d6a"), "vini.souza00@gmail.com", new Guid("fc73fc67-5137-4830-8f8c-425766ef4d6a"), new Guid("07b49006-1b80-4784-9de9-f535050e1aad"), "Vinicius Nascimento", "N/A", "333333333", 1, 1, null });

            migrationBuilder.UpdateData(
                table: "Municipio",
                keyColumn: "Id",
                keyValue: new Guid("f0a1a069-3db3-4f31-b71d-20074e3b861b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6063));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6079));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6263));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("20792100-80af-49a8-8195-f7c36441c38d"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6049));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("275002db-aa62-444e-a179-b801583c3568"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6042));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6047));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("3b72bc3f-4613-4313-963c-9621db443e32"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6069));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6039));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6256));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6077));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6259));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 14, 1, 7, 20, 854, DateTimeKind.Utc).AddTicks(6020));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6261));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6051));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6029));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6082));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6058));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6065));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "Uf",
                keyColumn: "Id",
                keyValue: new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"),
                column: "CreateAt",
                value: new DateTime(2022, 1, 13, 22, 7, 20, 854, DateTimeKind.Local).AddTicks(6067));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
