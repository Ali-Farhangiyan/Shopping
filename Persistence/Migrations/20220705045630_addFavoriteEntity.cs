using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addFavoriteEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 730, DateTimeKind.Local).AddTicks(767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 780, DateTimeKind.Local).AddTicks(1028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(7131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(7600));

            migrationBuilder.AddColumn<int>(
                name: "FavoriteCount",
                schema: "dbo",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(3152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 778, DateTimeKind.Local).AddTicks(2806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(5942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 778, DateTimeKind.Local).AddTicks(5467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(5067),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(5425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(3482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(3879));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(1926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(2159));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(9743),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 778, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 727, DateTimeKind.Local).AddTicks(8635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 777, DateTimeKind.Local).AddTicks(7213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 777, DateTimeKind.Local).AddTicks(8945));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(1967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 778, DateTimeKind.Local).AddTicks(822));

            migrationBuilder.CreateTable(
                name: "Favorites",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteProduct",
                schema: "dbo",
                columns: table => new
                {
                    FavoritesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteProduct", x => new { x.FavoritesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_Favorites_FavoritesId",
                        column: x => x.FavoritesId,
                        principalSchema: "dbo",
                        principalTable: "Favorites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalSchema: "dbo",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProduct_ProductsId",
                schema: "dbo",
                table: "FavoriteProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteProduct",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Favorites",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "FavoriteCount",
                schema: "dbo",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 780, DateTimeKind.Local).AddTicks(1028),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 730, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(7600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 778, DateTimeKind.Local).AddTicks(2806),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 778, DateTimeKind.Local).AddTicks(5467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(5425),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(3879),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(3482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(2159),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 779, DateTimeKind.Local).AddTicks(27),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 778, DateTimeKind.Local).AddTicks(7845),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 777, DateTimeKind.Local).AddTicks(7213),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 727, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 777, DateTimeKind.Local).AddTicks(8945),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 4, 17, 33, 8, 778, DateTimeKind.Local).AddTicks(822),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(1967));
        }
    }
}
