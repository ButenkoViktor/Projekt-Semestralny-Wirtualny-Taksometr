using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfProjektWirtualnyTaksometr.Migrations
{
    /// <inheritdoc />
    public partial class DodanoNazwiskoIMiejsceStartu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adres",
                table: "Klienci",
                newName: "Nazwisko");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataZamowienia",
                table: "Klienci",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MiejsceStartu",
                table: "Klienci",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DataZamowienia", "Imie", "MiejsceStartu", "Nazwisko" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jan", "Warszawa", "Kowalski" });

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataZamowienia", "Imie", "MiejsceStartu", "Nazwisko" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anna", "Krakow", "Nowak" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataZamowienia",
                table: "Klienci");

            migrationBuilder.DropColumn(
                name: "MiejsceStartu",
                table: "Klienci");

            migrationBuilder.RenameColumn(
                name: "Nazwisko",
                table: "Klienci",
                newName: "Adres");

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Adres", "Imie" },
                values: new object[] { "Warszawa", "Jan Kowalski" });

            migrationBuilder.UpdateData(
                table: "Klienci",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Adres", "Imie" },
                values: new object[] { "Krakow", "Anna Nowak" });
        }
    }
}
