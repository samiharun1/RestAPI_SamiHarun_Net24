using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI_SamiHarun_Net24.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktInfo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Erfarenheter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Företag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    År = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Erfarenheter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Erfarenheter_Personer_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utbildningar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Examen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlutDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utbildningar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utbildningar_Personer_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Erfarenheter_PersonId",
                table: "Erfarenheter",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Utbildningar_PersonId",
                table: "Utbildningar",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Erfarenheter");

            migrationBuilder.DropTable(
                name: "Utbildningar");

            migrationBuilder.DropTable(
                name: "Personer");
        }
    }
}
