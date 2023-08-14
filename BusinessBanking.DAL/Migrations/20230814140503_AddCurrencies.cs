using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessBanking.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrencies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "ID",
                keyValue: 24);
        }
    }
}
