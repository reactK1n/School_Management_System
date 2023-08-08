using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagerSystem.Data.Migrations
{
    public partial class addProfilePicsToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePics",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePics",
                table: "AspNetUsers");
        }
    }
}
