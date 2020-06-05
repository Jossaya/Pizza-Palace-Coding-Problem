using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza_Palace_Coding_Problem.EF.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTotal = table.Column<double>(nullable: false),
                    TaxTotal = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaSizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToppingCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToppingCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<double>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemIsATopping = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaSizeId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_PizzaSizes_PizzaSizeId",
                        column: x => x.PizzaSizeId,
                        principalTable: "PizzaSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaSizeId = table.Column<int>(nullable: false),
                    ToppingCategoryId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toppings_PizzaSizes_PizzaSizeId",
                        column: x => x.PizzaSizeId,
                        principalTable: "PizzaSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Toppings_ToppingCategories_ToppingCategoryId",
                        column: x => x.ToppingCategoryId,
                        principalTable: "ToppingCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PizzaSizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Small" },
                    { 2, "Medium" },
                    { 3, "Large" }
                });

            migrationBuilder.InsertData(
                table: "ToppingCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Basic Toppings" },
                    { 2, "Deluxe Toppings" }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "PizzaSizeId", "Price" },
                values: new object[,]
                {
                    { 1, 1, 12.0 },
                    { 2, 2, 14.0 },
                    { 3, 3, 16.0 }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name", "PizzaSizeId", "Price", "ToppingCategoryId" },
                values: new object[,]
                {
                    { 22, "Olives", 1, 2.0, 2 },
                    { 21, "Tomatoes", 3, 4.0, 2 },
                    { 20, "Tomatoes", 2, 3.0, 2 },
                    { 19, "Tomatoes", 1, 2.0, 2 },
                    { 18, "Feta Cheese", 3, 4.0, 2 },
                    { 17, "Feta Cheese", 2, 3.0, 2 },
                    { 16, "Feta Cheese", 1, 2.0, 2 },
                    { 15, "Sausage", 3, 4.0, 2 },
                    { 14, "Sausage", 2, 3.0, 2 },
                    { 13, "Sausage", 1, 2.0, 2 },
                    { 12, "Pineapple", 3, 1.0, 1 },
                    { 11, "Pineapple", 2, 0.75, 1 },
                    { 10, "Pineapple", 1, 0.5, 1 },
                    { 9, "Ham", 3, 1.0, 1 },
                    { 8, "Ham", 2, 0.75, 1 },
                    { 7, "Ham", 1, 0.5, 1 },
                    { 6, "Pepperoni", 3, 1.0, 1 },
                    { 5, "Pepperoni", 2, 0.75, 1 },
                    { 4, "Pepperoni", 1, 0.5, 1 },
                    { 3, "Cheese", 3, 1.0, 1 },
                    { 2, "Cheese", 2, 0.75, 1 },
                    { 1, "Cheese", 1, 0.5, 1 },
                    { 23, "Olives", 2, 3.0, 2 },
                    { 24, "Olives", 3, 4.0, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaSizeId",
                table: "Pizzas",
                column: "PizzaSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_PizzaSizeId",
                table: "Toppings",
                column: "PizzaSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Toppings_ToppingCategoryId",
                table: "Toppings",
                column: "ToppingCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PizzaSizes");

            migrationBuilder.DropTable(
                name: "ToppingCategories");
        }
    }
}
