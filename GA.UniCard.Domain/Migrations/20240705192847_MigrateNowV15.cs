using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GA.UniCard.Domain.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNowV15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 75m, 3 });

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
                column: "Product_Price",
                value: 80m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Product_Price",
                value: 26m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Product_Price",
                value: 83m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Product_Price",
                value: 12m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Product_Price",
                value: 54m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Product_Price",
                value: 89m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Product_Price",
                value: 63m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Product_Price",
                value: 46m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 72m, 8 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 79m, 2 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 97m, 9 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 33m, 7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 73m, 7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 31m, 6 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 77m, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 15, 23, 25, 22, 866, DateTimeKind.Local).AddTicks(2373), 717m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 12, 23, 25, 22, 866, DateTimeKind.Local).AddTicks(2396), 544m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 5, 23, 25, 22, 866, DateTimeKind.Local).AddTicks(2398), 328m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 10, 23, 25, 22, 866, DateTimeKind.Local).AddTicks(2399), 110m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 13, 23, 25, 22, 866, DateTimeKind.Local).AddTicks(2401), 251m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 3, 23, 25, 22, 866, DateTimeKind.Local).AddTicks(2403), 226m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Product_Price",
                value: 97m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Product_Price",
                value: 71m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Product_Price",
                value: 21m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Product_Price",
                value: 72m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Product_Price",
                value: 49m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Product_Price",
                value: 36m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Product_Price",
                value: 86m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Product_Price",
                value: 64m);
        }
    }
}
