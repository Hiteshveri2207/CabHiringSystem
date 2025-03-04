using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CustomerTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
