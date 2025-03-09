using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_SamiHarun_Net24.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Personer",
                columns: new[] { "Id", "Beskrivning", "KontaktInfo", "Namn" },
                values: new object[] { 1, "Fullstack .NET utvecklare", "sami@example.com", "Sami Harun" });

            migrationBuilder.InsertData(
                table: "Erfarenheter",
                columns: new[] { "Id", "Företag", "JobTitel", "PersonId", "År" },
                values: new object[] { 1, "Spotify", "Software Developer", 1, 2021 });

            migrationBuilder.InsertData(
                table: "Utbildningar",
                columns: new[] { "Id", "Examen", "PersonId", "Skola", "SlutDatum", "StartDatum" },
                values: new object[] { 1, "Civilingenjör", 1, "Chalmers Tekniska Högskola", new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Erfarenheter",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Utbildningar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personer",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
