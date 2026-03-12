using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ActivityTracking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnergyUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UnitsConsumed = table.Column<double>(type: "float", nullable: false),
                    CarbonEmission = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyUsages_Activities_Id",
                        column: x => x.Id,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    TransportMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DistanceKm = table.Column<double>(type: "float", nullable: false),
                    CarbonEmission = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportActivities_Activities_Id",
                        column: x => x.Id,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WasteActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    WeightKg = table.Column<double>(type: "float", nullable: false),
                    CarbonEmission = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WasteActivities_Activities_Id",
                        column: x => x.Id,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyUsages");

            migrationBuilder.DropTable(
                name: "TransportActivities");

            migrationBuilder.DropTable(
                name: "WasteActivities");

            migrationBuilder.DropTable(
                name: "Activities");
        }
    }
}
