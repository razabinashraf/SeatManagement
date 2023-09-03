using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatManagement.Migrations
{
    public partial class seats_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpenRoomsSeatMaps_Employees_EmployeeId",
                table: "OpenRoomsSeatMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenRoomsSeatMaps_Facilities_FacilityId",
                table: "OpenRoomsSeatMaps");

            migrationBuilder.DropTable(
                name: "OpenRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OpenRoomsSeatMaps",
                table: "OpenRoomsSeatMaps");

            migrationBuilder.RenameTable(
                name: "OpenRoomsSeatMaps",
                newName: "Seats");

            migrationBuilder.RenameIndex(
                name: "IX_OpenRoomsSeatMaps_FacilityId",
                table: "Seats",
                newName: "IX_Seats_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_OpenRoomsSeatMaps_EmployeeId",
                table: "Seats",
                newName: "IX_Seats_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Facilities_FacilityId",
                table: "Seats",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Employees_EmployeeId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Facilities_FacilityId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "OpenRoomsSeatMaps");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_FacilityId",
                table: "OpenRoomsSeatMaps",
                newName: "IX_OpenRoomsSeatMaps_FacilityId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_EmployeeId",
                table: "OpenRoomsSeatMaps",
                newName: "IX_OpenRoomsSeatMaps_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OpenRoomsSeatMaps",
                table: "OpenRoomsSeatMaps",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OpenRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenRooms_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpenRooms_FacilityId",
                table: "OpenRooms",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OpenRoomsSeatMaps_Employees_EmployeeId",
                table: "OpenRoomsSeatMaps",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OpenRoomsSeatMaps_Facilities_FacilityId",
                table: "OpenRoomsSeatMaps",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
