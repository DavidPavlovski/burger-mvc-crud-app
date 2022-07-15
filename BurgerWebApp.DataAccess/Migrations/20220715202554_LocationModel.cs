using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerWebApp.DataAccess.Migrations
{
    public partial class LocationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpensAt = table.Column<int>(type: "int", nullable: false),
                    ClosesAt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Address", "ClosesAt", "Name", "OpensAt" },
                values: new object[,]
                {
                    { 1, "Partizanski orderdi", 22, "Dacos burgers Skopje Centar", 8 },
                    { 2, "Jane Sandanski", 22, "Dacos burgers Skopje Aerodrom", 8 },
                    { 3, "7mi Noemvri", 22, "Dacos burgers Ohrid", 8 },
                    { 4, "Ilindenska", 22, "Dacos burgers Bitola", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_LocationId",
                table: "Order",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Location_LocationId",
                table: "Order",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Location_LocationId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Order_LocationId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Order");
        }
    }
}
