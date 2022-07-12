using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerWebApp.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Burger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVegan = table.Column<bool>(type: "bit", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extra", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BurgerOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurgerId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BurgerOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BurgerOrderItem_Burger_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BurgerOrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraOrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraOrderItem_Extra_ExtraId",
                        column: x => x.ExtraId,
                        principalTable: "Extra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraOrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Burger",
                columns: new[] { "Id", "ImageUrl", "Ingredients", "IsVegan", "IsVegetarian", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2018/4/1/0/LS-Library_Breakfast-Sausage-Egg-Burger_s4x3.jpg.rend.hgtvcom.616.462.suffix/1522644655757.jpeg", "Bun , Sausage , Egg , Tomato , Letuce , Onions", false, false, "Breakfast burger", 150m },
                    { 2, "https://assets.epicurious.com/photos/57c5c6d9cf9e9ad43de2d96e/master/pass/the-ultimate-hamburger.jpg", "Bun , Beef patty, Tomato ,Letuce , Onions", false, false, "Hamburger", 180m },
                    { 3, "https://i.pinimg.com/originals/8b/61/11/8b611136ead0d4c247f0fef92925f284.jpg", "Bun , Beef patty , Cheese , Tomato , Letuse , Onions", false, false, "Cheese Burger", 200m },
                    { 4, "https://makeyourmeals.com/wp-content/uploads/2020/05/bacon-cheeseburger-featured-720x540.jpg", "Bun , Beef patty , Tomato , Letuce , Onions , Bacon", false, false, "Bacon Burger", 250m },
                    { 5, "https://www.hardees.com/-/media/project/cke/hardees/double-cheeseburger-705-x-401.jpgs", "Bun , 2 x Beef patty , Tomato , Letuce , Onions, Cheese", false, false, "Double cheese burger", 250m },
                    { 6, "https://groundbeefrecipes.com/wp-content/uploads/double-bacon-cheeseburger-recipe-6.jpg", "Bun , 2 x Beef patty , Tomato , Letuce , Onions , Cheese , Bacon", false, false, "Double bacon cheese burger", 300m },
                    { 7, "https://i.ytimg.com/vi/a19EY3YNStA/maxresdefault.jpg", "Whole Wheat Bun Bun , Veggie patty , Tomato , Letuce , Onions", true, true, "Veggie Burger", 120m },
                    { 8, "https://img.sunset02.com/sites/default/files/styles/4_3_horizontal_-_900x675/public/zucchini-burgers-su.jpg", "Whole Wheat Bun , Zucchini patty , Tomato , Letuce , Cucumber , Oninons", false, true, "Zucchini Burger", 120m }
                });

            migrationBuilder.InsertData(
                table: "Extra",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Small fries", 30m },
                    { 2, "Large fries", 60m },
                    { 3, "Small waffle fries", 50m },
                    { 4, "Large waffle fries", 80m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrderItem_BurgerId",
                table: "BurgerOrderItem",
                column: "BurgerId");

            migrationBuilder.CreateIndex(
                name: "IX_BurgerOrderItem_OrderId",
                table: "BurgerOrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOrderItem_ExtraId",
                table: "ExtraOrderItem",
                column: "ExtraId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraOrderItem_OrderId",
                table: "ExtraOrderItem",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BurgerOrderItem");

            migrationBuilder.DropTable(
                name: "ExtraOrderItem");

            migrationBuilder.DropTable(
                name: "Burger");

            migrationBuilder.DropTable(
                name: "Extra");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
