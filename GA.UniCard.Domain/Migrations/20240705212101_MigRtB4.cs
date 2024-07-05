using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GA.UniCard.Domain.Migrations
{
    /// <inheritdoc />
    public partial class MigRtB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 46m, 7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 37m, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Item_Price",
                value: 43m);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 18m, 4 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 80m, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 90m, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 63m, 9 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 27, 1, 21, 0, 413, DateTimeKind.Local).AddTicks(981), 224m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 8, 1, 21, 0, 413, DateTimeKind.Local).AddTicks(1007), 969m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 20, 1, 21, 0, 413, DateTimeKind.Local).AddTicks(1009), 905m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 5, 1, 21, 0, 413, DateTimeKind.Local).AddTicks(1011), 605m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 20, 1, 21, 0, 413, DateTimeKind.Local).AddTicks(1013), 961m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 2, 1, 21, 0, 413, DateTimeKind.Local).AddTicks(1014), 986m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "The milk is good produce in mountains", 59m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "The Apple is good produce in mountains", 77m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "The Banana is good produce in mountains", 71m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "The Bread is good produce in mountains", 93m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "The Gold is good produce in mountains", 71m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "The Fish is good produce in mountains", 71m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "The Beans is good produce in mountains", 28m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Product_Description", "Product_Price", "Product_Name" },
                values: new object[] { "The Sugar is good produce in mountains", 34m, "Sugar" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 36m, 3 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 80m, 7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Item_Price",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 62m, 6 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 21m, 6 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 21m, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 53m, 3 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 2, 23, 28, 47, 468, DateTimeKind.Local).AddTicks(7227), 492m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 15, 23, 28, 47, 468, DateTimeKind.Local).AddTicks(7249), 418m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 9, 23, 28, 47, 468, DateTimeKind.Local).AddTicks(7251), 290m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 16, 23, 28, 47, 468, DateTimeKind.Local).AddTicks(7253), 112m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 14, 23, 28, 47, 468, DateTimeKind.Local).AddTicks(7254), 501m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 14, 23, 28, 47, 468, DateTimeKind.Local).AddTicks(7256), 482m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "THe milk is  good produce in mountins", 80m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "The Apple is  good produce in mountins", 26m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "THe Banana is  good produce in mountins", 83m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "THe Bread is  good produce in mountins", 12m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "THe Gold is  good produce in mountins", 54m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "THe Fish is  good produce in mountins", 89m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Product_Description", "Product_Price" },
                values: new object[] { "THe Beans is  good produce in mountins", 63m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Product_Description", "Product_Price", "Product_Name" },
                values: new object[] { "THe Suggar is  good produce in mountins", 46m, "Suggar" });
        }
    }
}
