using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addAuditToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(6225));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Tags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Tags",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(2414));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 166, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(6789));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(4691));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Categories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertTime",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 24, 11, 34, 42, 165, DateTimeKind.Local).AddTicks(2770));

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Brands",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTime",
                table: "Brands",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "InsertTime",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "UpdateTime",
                table: "Brands");
        }
    }
}
