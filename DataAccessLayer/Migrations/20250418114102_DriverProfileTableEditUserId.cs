using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class DriverProfileTableEditUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_AspNetUsers_UserId1",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Driver_UserId1",
                table: "Driver");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Driver");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Driver",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_UserId",
                table: "Driver",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_AspNetUsers_UserId",
                table: "Driver",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Driver_AspNetUsers_UserId",
                table: "Driver");

            migrationBuilder.DropIndex(
                name: "IX_Driver_UserId",
                table: "Driver");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Driver",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Driver",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Driver_UserId1",
                table: "Driver",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_AspNetUsers_UserId1",
                table: "Driver",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
