using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Domain.Migrations
{
    public partial class ManyFlights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Pilots_PilotID",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flight_PilotID",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "PilotID",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flights",
                columns: new[] { "PilotID", "FlightID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Pilots_PilotID",
                table: "Flights",
                column: "PilotID",
                principalTable: "Pilots",
                principalColumn: "PilotID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Pilots_PilotID",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flights");

            migrationBuilder.AlterColumn<int>(
                name: "PilotID",
                table: "Flights",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flights",
                column: "FlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_PilotID",
                table: "Flights",
                column: "PilotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Pilots_PilotID",
                table: "Flight",
                column: "PilotID",
                principalTable: "Pilots",
                principalColumn: "PilotID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
