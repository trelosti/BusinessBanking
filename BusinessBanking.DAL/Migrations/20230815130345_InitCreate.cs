using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessBanking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "char(25)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAccess = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.UniqueConstraint("AK_Users_CustomerID", x => x.CustomerID);
                    table.UniqueConstraint("AK_Users_Login", x => x.Login);
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

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "ID", "CurrencyID", "CurrencyName", "CurrencySymbol" },
                values: new object[,]
                {
                    { 1, "036", "Австралийский доллар", "AUD" },
                    { 2, "124", "Канадский доллар", "CAD" },
                    { 3, "156", "Китайский юань", "CNY" },
                    { 4, "203", "Чешская крона", "CZK" },
                    { 5, "250", "Французский франк", "FRF" },
                    { 6, "276", "Немецкая марка", "DEM" },
                    { 7, "392", "Японская йена", "JPY" },
                    { 8, "398", "Тенге", "KZT" },
                    { 9, "417", "Сом Кыргызской Республики", "KGS" },
                    { 10, "528", "Нидерландский гульден", "NLG" },
                    { 11, "643", "Российский рубль", "RUB" },
                    { 12, "724", "Испанская песета", "ESP" },
                    { 13, "752", "Шведская крона", "SEK" },
                    { 14, "756", "Швейцарский франк", "CHF" },
                    { 15, "784", "Дирхам ОАЭ", "AED" },
                    { 16, "826", "Английский фунт", "GBP" },
                    { 17, "840", "ДОЛЛАР США", "USD" },
                    { 18, "949", "Турецкая лира", "TRY" },
                    { 19, "959", "Золото", "XAU" },
                    { 20, "961", "Серебро", "XAG" },
                    { 21, "962", "Платина", "XPT" },
                    { 22, "974", "Белорусский рубль", "BYR" },
                    { 23, "978", "ЕВРО", "EUR" },
                    { 24, "980", "Украинская гривна", "UAH" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CustomerID", "Login", "Password", "UserAccess" },
                values: new object[,]
                {
                    { 1, 1, "user", "ee11cbb19052e40b07aac0ca060c23ee", 1 },
                    { 2, 2, "test", "098f6bcd4621d373cade4e832627b4f6", 1 }
                });

            migrationBuilder.InsertData(
                table: "CustomerAccounts",
                columns: new[] { "ID", "AccountName", "AccountNo", "AccountType", "AvailableBalance", "CloseDate", "CurrencyID", "CustomerID", "EndDate", "OpenDate" },
                values: new object[,]
                {
                    { 1, "Банковские счета юридических лиц", "1240020000000001", (byte)0, 137.53m, null, "840", 1, new DateTime(2024, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(7975), new DateTime(2023, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(7960) },
                    { 2, "Банковские счета ИП ", "1240020000000002", (byte)0, 49315.07m, null, "417", 1, new DateTime(2024, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(7988), new DateTime(2023, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(7987) },
                    { 3, "Классический 365/факт", "1243010000000001", (byte)1, 1000000m, null, "417", 1, new DateTime(2024, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(7993), new DateTime(2023, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(7992) },
                    { 4, "Банковские счета физ. лиц ", "1240020000000003", (byte)0, 1502.75m, null, "643", 2, new DateTime(2024, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(7998), new DateTime(2023, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(7997) },
                    { 5, "Классический 365/факт", "1243010000000002", (byte)1, 5000000m, null, "643", 2, new DateTime(2024, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(8003), new DateTime(2023, 8, 15, 19, 3, 45, 588, DateTimeKind.Local).AddTicks(8002) }
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

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
