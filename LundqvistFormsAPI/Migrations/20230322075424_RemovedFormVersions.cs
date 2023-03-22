using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LundqvistFormsAPI.Migrations
{
    public partial class RemovedFormVersions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormGroupId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "FormVersionName",
                table: "Forms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FormGroupId",
                table: "Forms",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "FormVersionName",
                table: "Forms",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
