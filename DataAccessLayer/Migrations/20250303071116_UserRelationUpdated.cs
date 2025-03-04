using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UserRelationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_UserId1",
                table: "Customer",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_UserId1",
                table: "Customer",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_UserId1",
                table: "Customer");

            migrationBuilder.DropIndex(
                name: "IX_Customer_UserId1",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
