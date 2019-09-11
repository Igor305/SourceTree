using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationApp.DataAccessLayer.Migrations
{
    public partial class Refresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRefreshTokens_AspNetUsers_UserId",
                table: "AspNetRefreshTokens");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetRefreshTokens",
                nullable: true,
                oldClrType: typeof(Guid),
                oldMaxLength: 450);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AspNetRefreshTokens",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRefreshTokens_AspNetUsers_UserId",
                table: "AspNetRefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRefreshTokens_AspNetUsers_UserId",
                table: "AspNetRefreshTokens");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AspNetRefreshTokens");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AspNetRefreshTokens",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRefreshTokens_AspNetUsers_UserId",
                table: "AspNetRefreshTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
