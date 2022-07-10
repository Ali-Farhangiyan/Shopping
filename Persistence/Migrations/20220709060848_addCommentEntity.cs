using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addCommentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Title",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Score",
                schema: "dbo",
                table: "Comments",
                newName: "StatusOfComment");

            migrationBuilder.RenameColumn(
                name: "NumberOfLike",
                schema: "dbo",
                table: "Comments",
                newName: "NumberOfLikes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 603, DateTimeKind.Local).AddTicks(8259),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 730, DateTimeKind.Local).AddTicks(767));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 603, DateTimeKind.Local).AddTicks(4011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(7131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(7709),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(3152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(9728),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 603, DateTimeKind.Local).AddTicks(36),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(5067));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 602, DateTimeKind.Local).AddTicks(7199),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(3482));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(4648),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(1926));

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                schema: "dbo",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDislikes",
                schema: "dbo",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentCommentId",
                schema: "dbo",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                schema: "dbo",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "dbo",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 602, DateTimeKind.Local).AddTicks(3383),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(9743));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 602, DateTimeKind.Local).AddTicks(1652),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(7967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(1132),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 727, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(2716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(6480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                schema: "dbo",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                schema: "dbo",
                table: "Comments",
                column: "ParentCommentId",
                principalSchema: "dbo",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentCommentId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "NumberOfDislikes",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Time",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "dbo",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "StatusOfComment",
                schema: "dbo",
                table: "Comments",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "NumberOfLikes",
                schema: "dbo",
                table: "Comments",
                newName: "NumberOfLike");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 730, DateTimeKind.Local).AddTicks(767),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 603, DateTimeKind.Local).AddTicks(8259));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(7131),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 603, DateTimeKind.Local).AddTicks(4011));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(3152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(7709));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "OrderItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(5942),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(9728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(5067),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 603, DateTimeKind.Local).AddTicks(36));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Features",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(3482),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 602, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 729, DateTimeKind.Local).AddTicks(1926),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(4648));

            migrationBuilder.AlterColumn<string>(
                name: "Body",
                schema: "dbo",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                schema: "dbo",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(9743),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 602, DateTimeKind.Local).AddTicks(3383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 602, DateTimeKind.Local).AddTicks(1652));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Baskets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 727, DateTimeKind.Local).AddTicks(8635),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(1132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "BasketItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(287),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(2716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InsertTime",
                schema: "dbo",
                table: "Addresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 5, 9, 26, 30, 728, DateTimeKind.Local).AddTicks(1967),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 7, 9, 10, 38, 48, 601, DateTimeKind.Local).AddTicks(6480));
        }
    }
}
