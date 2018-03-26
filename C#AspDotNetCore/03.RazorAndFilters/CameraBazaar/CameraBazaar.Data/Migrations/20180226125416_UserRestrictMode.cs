namespace CameraBazaar.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class UserRestrictMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RestrictToAddNewCameras",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestrictToAddNewCameras",
                table: "AspNetUsers");
        }
    }
}
