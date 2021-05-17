﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvestmentPerformance.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInvestments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvestmentId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInvestments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInvestments_Investments_InvestmentId",
                        column: x => x.InvestmentId,
                        principalTable: "Investments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserInvestmentId = table.Column<int>(type: "int", nullable: false),
                    CostBasisPerShare = table.Column<decimal>(type: "decimal(15,2)", precision: 15, scale: 2, nullable: false),
                    NumberOfShares = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_UserInvestments_UserInvestmentId",
                        column: x => x.UserInvestmentId,
                        principalTable: "UserInvestments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Investments",
                columns: new[] { "Id", "CreatedDate", "CurrentPrice", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 35.35m, "INVEST1", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 12.00m, "INVEST2", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 23.5m, "INVEST3", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), 19.22m, "INVEST4", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "UserInvestments",
                columns: new[] { "Id", "Active", "CreatedDate", "InvestmentId", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2020, 2, 13, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2020, 2, 13, 0, 0, 0, 0, DateTimeKind.Utc), "sXybwQ7JaDJ88jxAkBpTRWepUF4wfKvi@clients" },
                    { 4, true, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anotherUserId" },
                    { 6, true, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 1, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anotherUserId2" },
                    { 5, false, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 2, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anotherUserId" },
                    { 2, true, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), 3, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), "sXybwQ7JaDJ88jxAkBpTRWepUF4wfKvi@clients" },
                    { 3, false, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "sXybwQ7JaDJ88jxAkBpTRWepUF4wfKvi@clients" },
                    { 7, true, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), "anotherUserId2" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "CostBasisPerShare", "CreatedDate", "NumberOfShares", "UpdatedDate", "UserInvestmentId" },
                values: new object[,]
                {
                    { 1, 30.42m, new DateTime(2020, 2, 13, 0, 0, 0, 0, DateTimeKind.Utc), 25, new DateTime(2020, 2, 13, 0, 0, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, 33.22m, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), 100, new DateTime(2020, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 7, 31.00m, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 45, new DateTime(2021, 2, 1, 0, 0, 0, 0, DateTimeKind.Utc), 4 },
                    { 3, 19.23m, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), 35, new DateTime(2021, 1, 8, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 4, 12.75m, new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), 200, new DateTime(2021, 2, 16, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 5, 30.2m, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), 15, new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), 2 },
                    { 6, 10.98m, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), 55, new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserInvestmentId",
                table: "Purchases",
                column: "UserInvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_InvestmentId",
                table: "UserInvestments",
                column: "InvestmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvestments_UserId_InvestmentId",
                table: "UserInvestments",
                columns: new[] { "UserId", "InvestmentId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "UserInvestments");

            migrationBuilder.DropTable(
                name: "Investments");
        }
    }
}
