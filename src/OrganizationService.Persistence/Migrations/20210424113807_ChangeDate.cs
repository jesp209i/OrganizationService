using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrganizationService.Persistence.Migrations
{
    public partial class ChangeDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangedAt",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Organizations",
                newName: "ChangeDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChangeDate",
                table: "Organizations",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangedAt",
                table: "Organizations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
