using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBudget.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndTransactionToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Icon", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "-", "Food", "Expense" },
                    { 2, "-", "Travelling", "Expense" },
                    { 3, "+", "Work", "Income" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CategoryId", "DateTime", "Description", "ShortDescription", "Title" },
                values: new object[,]
                {
                    { 1, 500.0, 2, new DateTime(2023, 10, 3, 15, 23, 24, 296, DateTimeKind.Local).AddTicks(2489), "I bought a ticket to Antalya", null, "Flight to Turkey" },
                    { 2, 2000.0, 3, new DateTime(2023, 10, 3, 15, 23, 24, 296, DateTimeKind.Local).AddTicks(2537), "I got a salary ", null, "Got Salary" },
                    { 3, 300.0, 1, new DateTime(2023, 10, 3, 15, 23, 24, 296, DateTimeKind.Local).AddTicks(2541), "I bought food in costco ", null, "Costco" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryId",
                table: "Transactions",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
