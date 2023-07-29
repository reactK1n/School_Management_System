using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagerSystem.Data.Migrations
{
    public partial class ChangeAddressProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
