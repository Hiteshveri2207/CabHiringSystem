using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddressTableAddAddressLines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_UserId1",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_UserId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Address",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId1",
                table: "Address",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_UserId1",
                table: "Address",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
