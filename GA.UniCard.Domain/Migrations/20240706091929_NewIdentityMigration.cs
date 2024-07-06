using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GA.UniCard.Domain.Migrations
{
    /// <inheritdoc />
    public partial class NewIdentityMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "e05abdc2-993f-4107-9ddc-51a426d39680", "GigaGiga@gmail.com", false, false, null, null, null, null, null, false, "df7d98fb-42c1-4193-a07b-d7b9d5d2e9a2", false, "Guga$445" },
                    { "2", 0, "33a16f9f-c3d2-4e4b-85fb-2ae3039f92b8", "GugaG3434uga@gmail.com", false, false, null, null, null, null, null, false, "3c61df7a-8278-47f8-83a1-0cbd7a23aa56", false, "Guga13guga#43" },
                    { "3", 0, "376edc51-1fbf-44d5-9ef7-b080394b61cb", "3443@gmail.com", false, false, null, null, null, null, null, false, "0fd5e52d-90e6-468d-8109-cd63f744f9a8", false, "#3445" },
                    { "4", 0, "686c471e-6326-4397-a1bb-54f92e6f2022", "Guga4334Guga@gmail.com", false, false, null, null, null, null, null, false, "6d294996-524d-4164-9b6e-b433d35f33cb", false, "Gia3454" },
                    { "5", 0, "1fc9c69c-ea34-4154-a691-68161407b457", "344334@gmail.com", false, false, null, null, null, null, null, false, "ebde7d40-16a9-4678-8ad4-c0f7d33ea69c", false, "Gaga45454" },
                    { "6", 0, "bc2eb702-f9cf-4f8c-b08a-b7e2dbc4f26c", "GugaGu343ga@gmail.com", false, false, null, null, null, null, null, false, "212d31c0-7c17-40c6-9301-84bebfeaec5d", false, "Tekla$#43" },
                    { "7", 0, "03c47668-7a63-4faf-b3aa-2fee0d321b18", "Gug3434aGuga@gmail.com", false, false, null, null, null, null, null, false, "f4595ac3-dab9-40ec-aa64-c66699c355d9", false, "Tek3445" }
                });

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "PersonId",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                column: "PersonId",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                column: "PersonId",
                value: "3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4L,
                column: "PersonId",
                value: "4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5L,
                column: "PersonId",
                value: "5");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6L,
                column: "PersonId",
                value: "6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7L,
                column: "PersonId",
                value: "7");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PersonId",
                table: "Users",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_AspNetUsers_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_AspNetUsers_PersonId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Users_PersonId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Users");

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
                columns: new[] { "Item_Price", "Item_Quantity" },
                values: new object[] { 43m, 3 });

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
                column: "Product_Price",
                value: 59m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Product_Price",
                value: 77m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Product_Price",
                value: 71m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Product_Price",
                value: 93m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Product_Price",
                value: 71m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Product_Price",
                value: 71m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Product_Price",
                value: 28m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Product_Price",
                value: 34m);
        }
    }
}
