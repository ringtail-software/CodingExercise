using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestmentPerformanceApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvestmentDetails",
                columns: table => new
                {
                    InvestmentId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CostBasis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shares = table.Column<int>(type: "int", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ForeignKey_CompanyName", x => new { x.InvestmentId, x.CompanyName });
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    InvestmentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ForeignKey_UserId", x => new { x.InvestmentId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_UserId", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentDetails");

            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
