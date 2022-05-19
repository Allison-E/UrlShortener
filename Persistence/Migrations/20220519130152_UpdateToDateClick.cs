using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UrlShortener.Persistence.Migrations
{
    public partial class UpdateToDateClick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateClick_Links_LinkId",
                table: "DateClick");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateClick",
                table: "DateClick");

            migrationBuilder.RenameTable(
                name: "DateClick",
                newName: "DateClicks");

            migrationBuilder.RenameIndex(
                name: "IX_DateClick_LinkId",
                table: "DateClicks",
                newName: "IX_DateClicks_LinkId");

            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "DateClicks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "DateClicks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateClicks",
                table: "DateClicks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DateClicks_Links_LinkId",
                table: "DateClicks",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DateClicks_Links_LinkId",
                table: "DateClicks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DateClicks",
                table: "DateClicks");

            migrationBuilder.RenameTable(
                name: "DateClicks",
                newName: "DateClick");

            migrationBuilder.RenameIndex(
                name: "IX_DateClicks_LinkId",
                table: "DateClick",
                newName: "IX_DateClick_LinkId");

            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "DateClick",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "DateClick",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DateClick",
                table: "DateClick",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DateClick_Links_LinkId",
                table: "DateClick",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
