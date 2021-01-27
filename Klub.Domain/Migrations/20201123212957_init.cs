using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Domain.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    AirlineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    YearFounded = table.Column<int>(nullable: false),
                    NumberOfPlanes = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.AirlineID);
                    table.ForeignKey(
                        name: "FK_Airlines_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    PilotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Miles = table.Column<int>(nullable: false),
                    AirlineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.PilotID);
                    table.ForeignKey(
                        name: "FK_Pilots_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "AirlineID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DurationInMinutes = table.Column<int>(nullable: false),
                    StartDestination = table.Column<string>(nullable: true),
                    EndDestination = table.Column<string>(nullable: true),
                    PilotID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightID);
                    table.ForeignKey(
                        name: "FK_Flight_Pilots_PilotID",
                        column: x => x.PilotID,
                        principalTable: "Pilots",
                        principalColumn: "PilotID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_CountryId",
                table: "Airlines",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PilotID",
                table: "Flights",
                column: "PilotID");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_AirlineId",
                table: "Pilots",
                column: "AirlineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
