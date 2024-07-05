using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GA.UniCard.Domain.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Product_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Ordering_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Item_Quantity = table.Column<int>(type: "int", nullable: false),
                    Item_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Product_Description", "Product_Price", "Product_Name" },
                values: new object[,]
                {
                    { 1L, "THe milk is  good produce in mountins", 43m, "Milk" },
                    { 2L, "The Apple is  good produce in mountins", 61m, "Apple" },
                    { 3L, "THe Banana is  good produce in mountins", 29m, "Banana" },
                    { 4L, "THe Bread is  good produce in mountins", 94m, "Bread" },
                    { 5L, "THe Gold is  good produce in mountins", 90m, "Gold" },
                    { 6L, "THe Fish is  good produce in mountins", 62m, "Fish" },
                    { 7L, "THe Beans is  good produce in mountins", 30m, "Beans" },
                    { 8L, "THe Suggar is  good produce in mountins", 62m, "Suggar" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "User_Name" },
                values: new object[,]
                {
                    { 1L, "Aapkhazava22@gmail.com", "Guga123", "Guga123#" },
                    { 2L, "Guga342@gmail.com", "Gaga1234", "Guga13guga##" },
                    { 3L, "Aapkhazava22@gmail.com", "Giga12346$", "Guga123#" },
                    { 4L, "NikaArtmeladze@gmail.com", "Guga%34", "Guga123#" },
                    { 5L, "Giorgi123@gmail.com", "Giorgi324", "Guga123#" },
                    { 6L, "UniPayAdmin@gmail.com", "Admin", "Admin#" },
                    { 7L, "Aapkhazava2200@gmail.com", "User4562", "User#" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Ordering_Date", "Total_Amount", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 5, 30, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9043), 367m, 1L },
                    { 2L, new DateTime(2024, 5, 1, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9063), 919m, 2L },
                    { 3L, new DateTime(2024, 4, 23, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9065), 794m, 3L },
                    { 4L, new DateTime(2024, 6, 22, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9067), 911m, 4L },
                    { 5L, new DateTime(2024, 4, 9, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9068), 128m, 5L },
                    { 6L, new DateTime(2024, 6, 23, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9070), 634m, 6L }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Item_Price", "ProductId", "Item_Quantity" },
                values: new object[,]
                {
                    { 1L, 1L, 55m, 1L, 1 },
                    { 2L, 2L, 98m, 2L, 6 },
                    { 3L, 3L, 56m, 3L, 6 },
                    { 4L, 4L, 22m, 4L, 1 },
                    { 5L, 5L, 99m, 5L, 9 },
                    { 6L, 3L, 57m, 2L, 6 },
                    { 7L, 6L, 61m, 4L, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product_Name",
                table: "Products",
                column: "Product_Name",
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
