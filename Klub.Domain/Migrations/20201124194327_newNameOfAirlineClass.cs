using Microsoft.EntityFrameworkCore.Migrations;

namespace Airline.Domain.Migrations
{
    public partial class newNameOfAirlineClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilots_Airlines_AirlineId",
                table: "Pilots");

            migrationBuilder.DropIndex(
                name: "IX_Pilots_AirlineId",
                table: "Pilots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airlines",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "AirlineID",
                table: "Airlines");

            migrationBuilder.AddColumn<int>(
                name: "AirlinesId",
                table: "Pilots",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AirlinesID",
                table: "Airlines",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airlines",
                table: "Airlines",
                column: "AirlinesID");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_AirlinesId",
                table: "Pilots",
                column: "AirlinesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilots_Airlines_AirlinesId",
                table: "Pilots",
                column: "AirlinesId",
                principalTable: "Airlines",
                principalColumn: "AirlinesID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pilots_Airlines_AirlinesId",
                table: "Pilots");

            migrationBuilder.DropIndex(
                name: "IX_Pilots_AirlinesId",
                table: "Pilots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airlines",
                table: "Airlines");

            migrationBuilder.DropColumn(
                name: "AirlinesId",
                table: "Pilots");

            migrationBuilder.DropColumn(
                name: "AirlinesID",
                table: "Airlines");

            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "Pilots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AirlineID",
                table: "Airlines",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airlines",
                table: "Airlines",
                column: "AirlineID");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_AirlineId",
                table: "Pilots",
                column: "AirlineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pilots_Airlines_AirlineId",
                table: "Pilots",
                column: "AirlineId",
                principalTable: "Airlines",
                principalColumn: "AirlineID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
