using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAPI.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tumbnail = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OnSale",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tumbnail = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    SellerID = table.Column<int>(nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnSale", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SaledItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Tumbnail = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    SellerID = table.Column<int>(nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    BuyerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaledItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    DeleteDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Nick = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    SteamId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ID",
                table: "Items",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_OnSale_ID",
                table: "OnSale",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_SaledItems_ID",
                table: "SaledItems",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ID",
                table: "Users",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "OnSale");

            migrationBuilder.DropTable(
                name: "SaledItems");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
