using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GA.UniCard.Domain.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6d920564-95d4-444e-87e1-5fcdea4db1ad", "10a00969-66ce-4f1e-b30f-68cc10eb0cfb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f892689-011d-405c-9452-4c39e263bf3e", "4dc8bb58-e2e3-4d55-a5e7-f97244d13c16" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f06267e3-ce55-41d4-8bcc-89b25e847805", "e31454e7-4ac9-4adc-a64e-a1ad529b0e54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e63c41e9-4ef1-4d1e-9e1c-6e6a275c9b78", "57bca823-95c0-49cc-8732-90a67d8574fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "32af51e7-6054-4009-a55e-c2e023ce75a5", "9c0f2a78-4433-49c2-bc2d-f47dadef5d9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "35a4c394-51cc-4bbc-9f52-154d69d57d2e", "5efb3628-e56e-4383-88b1-49b49363b7f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "504cb420-8b41-41b9-9216-d043bb0d52ce", "ee74caab-faea-4a84-a34f-1aa776ae2b5f" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 86m, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 62m, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 67m, 9 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 95m, 7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 85m, 9 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 54m, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 49m, 2 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 8, 21, 43, 22, 450, DateTimeKind.Local).AddTicks(7861), 353m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 24, 21, 43, 22, 450, DateTimeKind.Local).AddTicks(7890), 411m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 3, 31, 21, 43, 22, 450, DateTimeKind.Local).AddTicks(7894), 703m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 23, 21, 43, 22, 450, DateTimeKind.Local).AddTicks(7897), 670m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 21, 21, 43, 22, 450, DateTimeKind.Local).AddTicks(7900), 118m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 22, 21, 43, 22, 450, DateTimeKind.Local).AddTicks(7904), 400m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Product_Price",
                value: 87m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Product_Price",
                value: 94m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Product_Price",
                value: 81m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Product_Price",
                value: 53m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Product_Price",
                value: 87m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Product_Price",
                value: 97m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Product_Price",
                value: 74m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Product_Price",
                value: 83m);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e05abdc2-993f-4107-9ddc-51a426d39680", "df7d98fb-42c1-4193-a07b-d7b9d5d2e9a2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "33a16f9f-c3d2-4e4b-85fb-2ae3039f92b8", "3c61df7a-8278-47f8-83a1-0cbd7a23aa56" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "376edc51-1fbf-44d5-9ef7-b080394b61cb", "0fd5e52d-90e6-468d-8109-cd63f744f9a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "686c471e-6326-4397-a1bb-54f92e6f2022", "6d294996-524d-4164-9b6e-b433d35f33cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1fc9c69c-ea34-4154-a691-68161407b457", "ebde7d40-16a9-4678-8ad4-c0f7d33ea69c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "bc2eb702-f9cf-4f8c-b08a-b7e2dbc4f26c", "212d31c0-7c17-40c6-9301-84bebfeaec5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "03c47668-7a63-4faf-b3aa-2fee0d321b18", "f4595ac3-dab9-40ec-aa64-c66699c355d9" });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 91m, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 32m, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 45m, 8 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 77m, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 82m, 5 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 75m, 7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 98m, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 17, 13, 19, 29, 433, DateTimeKind.Local).AddTicks(2645), 932m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 19, 13, 19, 29, 433, DateTimeKind.Local).AddTicks(2664), 168m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 14, 13, 19, 29, 433, DateTimeKind.Local).AddTicks(2666), 778m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 21, 13, 19, 29, 433, DateTimeKind.Local).AddTicks(2668), 991m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 7, 13, 19, 29, 433, DateTimeKind.Local).AddTicks(2670), 759m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 20, 13, 19, 29, 433, DateTimeKind.Local).AddTicks(2672), 683m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Product_Price",
                value: 43m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Product_Price",
                value: 83m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Product_Price",
                value: 95m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Product_Price",
                value: 37m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Product_Price",
                value: 78m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Product_Price",
                value: 57m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Product_Price",
                value: 99m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Product_Price",
                value: 73m);
        }
    }
}
