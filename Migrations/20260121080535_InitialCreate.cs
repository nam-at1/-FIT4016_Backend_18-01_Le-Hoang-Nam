using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Sku = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CustomerEmail = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "Price", "Sku", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Books", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 1", "Product 1", 671.14m, "SKU0001", 13, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Books", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 2", "Product 2", 176.26m, "SKU0002", 72, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Clothing", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 3", "Product 3", 181.76m, "SKU0003", 24, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Clothing", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 4", "Product 4", 510.32m, "SKU0004", 38, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Books", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 5", "Product 5", 522.04m, "SKU0005", 81, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Home", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 6", "Product 6", 403.15m, "SKU0006", 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Home", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 7", "Product 7", 818.54m, "SKU0007", 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Books", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 8", "Product 8", 156.91m, "SKU0008", 69, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Books", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 9", "Product 9", 194.04m, "SKU0009", 31, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Sports", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 10", "Product 10", 822.00m, "SKU0010", 54, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Electronics", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 11", "Product 11", 750.38m, "SKU0011", 15, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "Electronics", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 12", "Product 12", 60.78m, "SKU0012", 63, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "Home", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 13", "Product 13", 257.77m, "SKU0013", 29, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "Books", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 14", "Product 14", 152.04m, "SKU0014", 60, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "Home", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description for Product 15", "Product 15", 60.42m, "SKU0015", 70, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CustomerEmail", "CustomerName", "DeliveryDate", "OrderDate", "OrderNumber", "ProductId", "Quantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer1@example.com", "John Doe", new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20240101-0001", 1, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer2@example.com", "Jane Smith", null, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231231-0002", 2, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer3@example.com", "Bob Johnson", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231230-0003", 3, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer4@example.com", "Alice Brown", null, new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231229-0004", 4, 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer5@example.com", "Charlie Wilson", new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231228-0005", 5, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer6@example.com", "Diana Prince", null, new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231227-0006", 6, 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer7@example.com", "Eve Adams", new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231226-0007", 7, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer8@example.com", "Frank Miller", null, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231225-0008", 8, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer9@example.com", "Grace Lee", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231224-0009", 9, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer10@example.com", "Henry Ford", null, new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231223-0010", 10, 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer11@example.com", "John Doe", new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231222-0011", 11, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer12@example.com", "Jane Smith", null, new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231221-0012", 12, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer13@example.com", "Bob Johnson", new DateTime(2023, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231220-0013", 13, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer14@example.com", "Alice Brown", null, new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231219-0014", 14, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer15@example.com", "Charlie Wilson", new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231218-0015", 15, 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer16@example.com", "Diana Prince", null, new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231217-0016", 1, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer17@example.com", "Eve Adams", new DateTime(2023, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231216-0017", 2, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer18@example.com", "Frank Miller", null, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231215-0018", 3, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer19@example.com", "Grace Lee", new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231214-0019", 4, 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer20@example.com", "Henry Ford", null, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231213-0020", 5, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer21@example.com", "John Doe", new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231212-0021", 6, 9, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer22@example.com", "Jane Smith", null, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231211-0022", 7, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer23@example.com", "Bob Johnson", new DateTime(2023, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231210-0023", 8, 5, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer24@example.com", "Alice Brown", null, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231209-0024", 9, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer25@example.com", "Charlie Wilson", new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231208-0025", 10, 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer26@example.com", "Diana Prince", null, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231207-0026", 11, 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer27@example.com", "Eve Adams", new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231206-0027", 12, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer28@example.com", "Frank Miller", null, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231205-0028", 13, 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer29@example.com", "Grace Lee", new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231204-0029", 14, 4, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer30@example.com", "Henry Ford", null, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "ORD-20231203-0030", 15, 8, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEmail",
                table: "Orders",
                column: "CustomerEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sku",
                table: "Products",
                column: "Sku",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
