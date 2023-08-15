using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessBanking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(4991), new DateTime(2023, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(4973) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(5004), new DateTime(2023, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(5002) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(5010), new DateTime(2023, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(5009) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CustomerID", "Login", "Password", "UserAccess" },
                values: new object[] { 2, 2, "test", "098f6bcd4621d373cade4e832627b4f6", 1 });

            migrationBuilder.InsertData(
                table: "CustomerAccounts",
                columns: new[] { "ID", "AccountName", "AccountNo", "AccountType", "AvailableBalance", "CloseDate", "CurrencyID", "CustomerID", "EndDate", "OpenDate" },
                values: new object[,]
                {
                    { 4, "Банковские счета физ. лиц ", "1240020000000003", (byte)0, 1502.75m, null, "643", 2, new DateTime(2024, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(5015), new DateTime(2023, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(5014) },
                    { 5, "Классический 365/факт", "1243010000000002", (byte)1, 5000000m, null, "643", 2, new DateTime(2024, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(5020), new DateTime(2023, 8, 15, 12, 52, 40, 618, DateTimeKind.Local).AddTicks(5019) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1667), new DateTime(2023, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1653) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1679), new DateTime(2023, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1678) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1687), new DateTime(2023, 8, 14, 21, 19, 31, 703, DateTimeKind.Local).AddTicks(1686) });
        }
    }
}
