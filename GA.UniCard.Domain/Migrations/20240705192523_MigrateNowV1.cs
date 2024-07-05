using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GA.UniCard.Domain.Migrations
{
    /// <inheritdoc />
    public partial class MigrateNowV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                column: "Item_Price",
                value: 31m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 55m, 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 98m, 6 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 56m, 6 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 22m, 1 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 99m, 9 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Item_Price",
                value: 57m);

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 61m, 6 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 30, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9043), 367m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 5, 1, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9063), 919m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 23, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9065), 794m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 22, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9067), 911m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 4, 9, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9068), 128m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Ordering_Date", "Total_Amount" },
                values: new object[] { new DateTime(2024, 6, 23, 23, 23, 40, 192, DateTimeKind.Local).AddTicks(9070), 634m });

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
                value: 61m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Product_Price",
                value: 29m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Product_Price",
                value: 94m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Product_Price",
                value: 90m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Product_Price",
                value: 62m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Product_Price",
                value: 30m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Product_Price",
                value: 62m);
        }
    }
}
