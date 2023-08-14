using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessBanking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestAccounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CustomerAccounts",
                columns: new[] { "ID", "AccountName", "AccountNo", "AccountType", "AvailableBalance", "CloseDate", "CurrencyID", "CustomerID", "EndDate", "OpenDate" },
                values: new object[,]
                {
                    { 1, "Банковские счета юридических лиц", "1240020000000001", (byte)0, 137.53m, null, "840", 1, new DateTime(2024, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1667), new DateTime(2023, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1653) },
                    { 2, "Банковские счета ИП ", "1240020000000002", (byte)0, 49315.07m, null, "417", 1, new DateTime(2024, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1679), new DateTime(2023, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1678) },
                    { 3, "Классический 365/факт", "1243010000000001", (byte)1, 1000000m, null, "417", 1, new DateTime(2024, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1687), new DateTime(2023, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1686) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
