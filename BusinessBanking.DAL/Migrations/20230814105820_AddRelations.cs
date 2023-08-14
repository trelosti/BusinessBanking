using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessBanking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Users_CustomerID",
                table: "Users",
                column: "CustomerID");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyID = table.Column<string>(type: "char(3)", nullable: false),
                    CurrencySymbol = table.Column<string>(type: "varchar(500)", nullable: false),
                    CurrencyName = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.ID);
                    table.UniqueConstraint("AK_Currencies_CurrencyID", x => x.CurrencyID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AccountType = table.Column<byte>(type: "tinyint", nullable: false),
                    AccountNo = table.Column<string>(type: "char(16)", nullable: false),
                    CurrencyID = table.Column<string>(type: "char(3)", nullable: false),
                    AccountName = table.Column<string>(type: "varchar(500)", nullable: false),
                    AvailableBalance = table.Column<decimal>(type: "decimal(17,2)", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Currencies_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "Currencies",
                        principalColumn: "CurrencyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Users_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Users",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CurrencyID",
                table: "CustomerAccounts",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerID",
                table: "CustomerAccounts",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Users_CustomerID",
                table: "Users");
        }
    }
}
