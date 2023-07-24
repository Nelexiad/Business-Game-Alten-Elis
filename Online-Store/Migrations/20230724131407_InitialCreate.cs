using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Store.Migrations
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
                    ID_Product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID_Product);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ID_Shop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ID_Shop);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.ID_User);
                });

            migrationBuilder.CreateTable(
                name: "Available_Products",
                columns: table => new
                {
                    ID_Available_Product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Shop = table.Column<int>(type: "int", nullable: false),
                    ID_Product = table.Column<int>(type: "int", nullable: false),
                    Available_Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Available_Products", x => x.ID_Available_Product);
                    table.ForeignKey(
                        name: "FK_Available_Products_Product",
                        column: x => x.ID_Product,
                        principalTable: "Products",
                        principalColumn: "ID_Product");
                    table.ForeignKey(
                        name: "FK_Available_Products_Shop",
                        column: x => x.ID_Shop,
                        principalTable: "Shops",
                        principalColumn: "ID_Shop");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    ID_Cart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.ID_Cart);
                    table.ForeignKey(
                        name: "FK_Cart_User",
                        column: x => x.ID_User,
                        principalTable: "Users",
                        principalColumn: "ID_User");
                });

            migrationBuilder.CreateTable(
                name: "Cart_Product",
                columns: table => new
                {
                    ID_Cart_Product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_Cart = table.Column<int>(type: "int", nullable: false),
                    ID_Product = table.Column<int>(type: "int", nullable: false),
                    Amout = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart_Product", x => x.ID_Cart_Product);
                    table.ForeignKey(
                        name: "FK_Cart_Cart",
                        column: x => x.ID_Cart,
                        principalTable: "Carts",
                        principalColumn: "ID_Cart");
                    table.ForeignKey(
                        name: "FK_Cart_Product_Product_Product",
                        column: x => x.ID_Product,
                        principalTable: "Products",
                        principalColumn: "ID_Product");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Available_Products_ID_Product",
                table: "Available_Products",
                column: "ID_Product");

            migrationBuilder.CreateIndex(
                name: "IX_Available_Products_ID_Shop",
                table: "Available_Products",
                column: "ID_Shop");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Product_ID_Cart",
                table: "Cart_Product",
                column: "ID_Cart");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Product_ID_Product",
                table: "Cart_Product",
                column: "ID_Product");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ID_User",
                table: "Carts",
                column: "ID_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Available_Products");

            migrationBuilder.DropTable(
                name: "Cart_Product");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
