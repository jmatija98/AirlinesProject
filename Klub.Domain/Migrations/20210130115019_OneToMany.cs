using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Domain.Migrations
{
    public partial class OneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Pilots_PilotID",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flights");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotID",
                table: "Flights",
                column: "PilotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Pilots_PilotID",
                table: "Flights",
                column: "PilotID",
                principalTable: "Pilots",
                principalColumn: "PilotID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Pilots_PilotID",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_PilotID",
                table: "Flights");

            migrationBuilder.RenameTable(
                name: "Flights",
                newName: "Flight");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                columns: new[] { "PilotID", "FlightID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Pilots_PilotID",
                table: "Flight",
                column: "PilotID",
                principalTable: "Pilots",
                principalColumn: "PilotID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
