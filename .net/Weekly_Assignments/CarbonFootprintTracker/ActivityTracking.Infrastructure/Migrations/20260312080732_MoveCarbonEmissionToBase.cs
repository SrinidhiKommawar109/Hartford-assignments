using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveCarbonEmissionToBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarbonEmission",
                table: "WasteActivities");

            migrationBuilder.DropColumn(
                name: "CarbonEmission",
                table: "TransportActivities");

            migrationBuilder.DropColumn(
                name: "CarbonEmission",
                table: "EnergyUsages");

            migrationBuilder.AddColumn<double>(
                name: "CarbonEmission",
                table: "Activities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarbonEmission",
                table: "Activities");

            migrationBuilder.AddColumn<double>(
                name: "CarbonEmission",
                table: "WasteActivities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CarbonEmission",
                table: "TransportActivities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "CarbonEmission",
                table: "EnergyUsages",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
