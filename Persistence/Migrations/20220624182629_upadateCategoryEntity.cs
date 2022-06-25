using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class upadateCategoryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 884, DateTimeKind.Local).AddTicks(4824),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 884, DateTimeKind.Local).AddTicks(1672),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(9591),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(7863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(6196),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(6789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(3905),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(1833),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(6225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 884, DateTimeKind.Local).AddTicks(4824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(2414),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 884, DateTimeKind.Local).AddTicks(1672));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(413),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(9591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(8619),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(7863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(6789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(6196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(4691),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(3905));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(2770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 24, 22, 56, 28, 883, DateTimeKind.Local).AddTicks(1833));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId",
                unique: true,
                filter: "[ParentCategoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
