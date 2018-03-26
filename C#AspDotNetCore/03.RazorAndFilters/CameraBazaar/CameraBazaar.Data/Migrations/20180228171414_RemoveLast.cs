using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CameraBazaar.Data.Migrations
{
    public partial class RemoveLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestrictToAddNewCameras",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RestrictToAddNewCameras",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }
    }
}
