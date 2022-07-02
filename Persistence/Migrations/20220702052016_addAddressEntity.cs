using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addAddressEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 189, DateTimeKind.Local).AddTicks(671),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 404, DateTimeKind.Local).AddTicks(9905));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(7543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 404, DateTimeKind.Local).AddTicks(3331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(5548),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 404, DateTimeKind.Local).AddTicks(1508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(4018),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(9912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(2335),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(476),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(6326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 187, DateTimeKind.Local).AddTicks(8767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 187, DateTimeKind.Local).AddTicks(4102),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 187, DateTimeKind.Local).AddTicks(5841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(2578));

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plaque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 187, DateTimeKind.Local).AddTicks(7594)),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RemoveTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 404, DateTimeKind.Local).AddTicks(9905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 189, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 404, DateTimeKind.Local).AddTicks(3331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 404, DateTimeKind.Local).AddTicks(1508),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(5548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(9912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(4018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(8133),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(2335));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(6326),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 188, DateTimeKind.Local).AddTicks(476));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(4453),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 187, DateTimeKind.Local).AddTicks(8767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(792),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 187, DateTimeKind.Local).AddTicks(4102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 30, 19, 0, 45, 403, DateTimeKind.Local).AddTicks(2578),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 2, 9, 50, 16, 187, DateTimeKind.Local).AddTicks(5841));
        }
    }
}
