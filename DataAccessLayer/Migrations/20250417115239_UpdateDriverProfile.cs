using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDriverProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
