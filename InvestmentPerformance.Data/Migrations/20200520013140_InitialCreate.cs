using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestmentPerformance.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TickerSymbol = table.Column<string>(nullable: true),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    StockId = table.Column<Guid>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Shares = table.Column<float>(nullable: false),
                    IsBuy = table.Column<bool>(nullable: false),
                    EventTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Investments_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Investments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "CurrentPrice", "TickerSymbol" },
                values: new object[,]
                {
                    { new Guid("d6459cc0-ab3d-45c2-93a1-6c8e650f0712"), 420.69m, "AAPL" },
                    { new Guid("d0cc01ae-4d7e-4ea7-b539-5309651dee77"), 1010.49m, "GOOGL" },
                    { new Guid("0a1973dc-8716-4d6c-990a-ee85dcfdf446"), 200.20m, "MSFT" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { new Guid("bb4c57b9-02d0-495a-8eaf-68973ef59894"), "Jordan_Belfort" },
                    { new Guid("858f4475-3628-4557-91f2-dd64e54f02cb"), "Warren_Buffet" },
                    { new Guid("ee7f4e2a-9212-4d19-99b0-073577fb6749"), "Joel_Gramling" }
                });

            migrationBuilder.InsertData(
                table: "Investments",
                columns: new[] { "Id", "EventTime", "IsBuy", "Price", "Shares", "StockId", "UserId" },
                values: new object[,]
                {
                    { new Guid("47ec638f-c192-4ba0-a09e-db698f10e84d"), new DateTime(2020, 5, 19, 1, 31, 40, 651, DateTimeKind.Utc).AddTicks(5062), true, 313.14m, 200f, new Guid("d6459cc0-ab3d-45c2-93a1-6c8e650f0712"), new Guid("bb4c57b9-02d0-495a-8eaf-68973ef59894") },
                    { new Guid("1c92a666-7942-4d4f-8dc0-81451f17b398"), new DateTime(2020, 5, 20, 1, 31, 40, 651, DateTimeKind.Utc).AddTicks(5705), false, 400.20m, 100f, new Guid("d6459cc0-ab3d-45c2-93a1-6c8e650f0712"), new Guid("bb4c57b9-02d0-495a-8eaf-68973ef59894") },
                    { new Guid("fa8f2ff7-e532-4400-97ae-b93c2d8aac4e"), new DateTime(2020, 5, 20, 1, 31, 40, 651, DateTimeKind.Utc).AddTicks(5739), true, 183.63m, 400f, new Guid("0a1973dc-8716-4d6c-990a-ee85dcfdf446"), new Guid("bb4c57b9-02d0-495a-8eaf-68973ef59894") },
                    { new Guid("16f45036-939b-45d3-ac5e-7707a6e70898"), new DateTime(2020, 5, 19, 1, 31, 40, 651, DateTimeKind.Utc).AddTicks(5757), true, 313.14m, 200f, new Guid("d6459cc0-ab3d-45c2-93a1-6c8e650f0712"), new Guid("858f4475-3628-4557-91f2-dd64e54f02cb") },
                    { new Guid("4fb14db1-7ec7-4363-ade8-b16c9392279d"), new DateTime(2020, 5, 20, 1, 31, 40, 651, DateTimeKind.Utc).AddTicks(5779), true, 400.20m, 100f, new Guid("d6459cc0-ab3d-45c2-93a1-6c8e650f0712"), new Guid("858f4475-3628-4557-91f2-dd64e54f02cb") },
                    { new Guid("b096bf84-b30c-4c7d-b3c6-ba3cb575f8aa"), new DateTime(2020, 5, 20, 1, 31, 40, 651, DateTimeKind.Utc).AddTicks(5798), true, 183.63m, 400f, new Guid("0a1973dc-8716-4d6c-990a-ee85dcfdf446"), new Guid("858f4475-3628-4557-91f2-dd64e54f02cb") },
                    { new Guid("7a4ee2c2-8982-4cce-bd93-84d6db110714"), new DateTime(2020, 5, 20, 1, 31, 40, 651, DateTimeKind.Utc).AddTicks(5815), true, 1374.40m, 0.4f, new Guid("d0cc01ae-4d7e-4ea7-b539-5309651dee77"), new Guid("ee7f4e2a-9212-4d19-99b0-073577fb6749") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Investments_StockId",
                table: "Investments",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Investments_UserId",
                table: "Investments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
