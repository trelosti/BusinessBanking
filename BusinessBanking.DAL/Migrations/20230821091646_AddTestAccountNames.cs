using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessBanking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTestAccountNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountNames",
                columns: new[] { "ID", "AccountName", "AccountNo", "CurrencyID", "CustomerID" },
                values: new object[,]
                {
                    { 1, "Банковские счета юр. лиц", "1240020000000001", "840", 1 },
                    { 2, "Счета ИП", "1240020000000002", "417", 1 },
                    { 3, "Классический 365", "1243010000000002", "643", 2 }
                });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6099), new DateTime(2023, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6085) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6109), new DateTime(2023, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6109) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6114), new DateTime(2023, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6113) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6117), new DateTime(2023, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6116) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6120), new DateTime(2023, 8, 21, 15, 16, 45, 978, DateTimeKind.Local).AddTicks(6120) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountNames",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountNames",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountNames",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6120), new DateTime(2023, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6133), new DateTime(2023, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6132) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6136), new DateTime(2023, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6136) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6140), new DateTime(2023, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6139) });

            migrationBuilder.UpdateData(
                table: "CustomerAccounts",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "EndDate", "OpenDate" },
                values: new object[] { new DateTime(2024, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6143), new DateTime(2023, 8, 21, 14, 30, 42, 409, DateTimeKind.Local).AddTicks(6142) });
        }
    }
}
