using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class TestDB_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    IdVehicleType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.IdVehicleType);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVehicleType = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(250)", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", nullable: false),
                    Type = table.Column<string>(type: "varchar(250)", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false),
                    LicensePlate = table.Column<string>(type: "varchar(250)", nullable: false),
                    Color = table.Column<string>(type: "varchar(250)", nullable: false),
                    NumberPassengers = table.Column<string>(type: "varchar(250)", nullable: false),
                    Photo = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_VehicleTypeIdVehicleType",
                        column: x => x.IdVehicleType,
                        principalTable: "VehicleTypes",
                        principalColumn: "IdVehicleType");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeIdVehicleType",
                table: "Vehicles",
                column: "IdVehicleType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
