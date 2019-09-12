using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EducationApp.DataAccessLayer.Migrations
{
    public partial class newBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRefreshTokens");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 450, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    ExpiresUtc = table.Column<DateTime>(nullable: false),
                    IssuedUtc = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(maxLength: 450, nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRefreshTokens_UserId",
                table: "AspNetRefreshTokens",
                column: "UserId");
        }
    }
}
