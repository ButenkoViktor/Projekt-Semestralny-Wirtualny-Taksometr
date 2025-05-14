using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WpfProjektWirtualnyTaksometr.Migrations
{
    /// <inheritdoc />
    public partial class DodanoDaneStartowe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Kilometry",
                table: "Przejazdy",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.InsertData(
                table: "Kierowcy",
                columns: new[] { "Id", "Email", "Imie", "IsDeleted", "Telefon", "statusKierowcy" },
                values: new object[,]
                {
                    { 1, "marek@taksometr.pl", "Marek Nowicki", false, "111222333", 0 },
                    { 2, "piotr@taksometr.pl", "Piotr Zielinski", false, "444555666", 1 }
                });

            migrationBuilder.InsertData(
                table: "Klienci",
                columns: new[] { "Id", "Adres", "Email", "Imie", "IsDeleted", "Telefon" },
                values: new object[,]
                {
                    { 1, "Warszawa", "jan@gmail.pl", "Jan Kowalski", false, "123456789" },
                    { 2, "Krakow", "anna@gmail.pl", "Anna Nowak", false, "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Taryfy",
                columns: new[] { "Id", "CenaZaKm", "TypTaryfa" },
                values: new object[,]
                {
                    { 1, 3.5m, "Dzien" },
                    { 2, 6.0m, "Noc" },
                    { 3, 8.4m, "Swieto" }
                });

            migrationBuilder.InsertData(
                table: "Pojazdy",
                columns: new[] { "Id", "KierowcaId", "Marka", "Model", "NumerRejestracyjny", "VIN" },
                values: new object[,]
                {
                    { 1, 1, "Toyota", "Corolla", "WX12345", "BR41491BT521F43W3" },
                    { 2, 2, "BMW", "X5", "KR98765", "BR41221DT121F43W3" }
                });

            migrationBuilder.InsertData(
                table: "Przejazdy",
                columns: new[] { "Id", "Cena", "Data", "KierowcaId", "Kilometry", "KlientId", "PunktKoncowy", "PunktStartowy", "RodzajPlatnosci", "Status", "TaryfaId" },
                values: new object[] { 1, 13.00m, new DateTime(2025, 5, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, 5.2m, 1, "Dworzec Centralny", "Plac Zbawiciela", 0, 2, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pojazdy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pojazdy",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Przejazdy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Taryfy",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Taryfy",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kierowcy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kierowcy",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Taryfy",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<double>(
                name: "Kilometry",
                table: "Przejazdy",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
