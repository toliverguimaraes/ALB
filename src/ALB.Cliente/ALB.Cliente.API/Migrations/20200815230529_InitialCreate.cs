using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ALB.Cliente.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Nome = table.Column<string>(nullable: true, maxLength:100),
                    Idade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
            migrationBuilder.InsertData("Cliente", new string[] { "Nome", "Idade" }, new object[] { "Tiago", 31 });
            migrationBuilder.InsertData("Cliente", new string[] { "Nome", "Idade" }, new object[] { "João", 25 });
            migrationBuilder.InsertData("Cliente", new string[] { "Nome", "Idade" }, new object[] { "Pedro", 38 });
            migrationBuilder.InsertData("Cliente", new string[] { "Nome", "Idade" }, new object[] { "Maria", 27 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
            name: "Cliente");
        }
    }
}
