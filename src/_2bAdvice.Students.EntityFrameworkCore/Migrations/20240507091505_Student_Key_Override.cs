using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2bAdvice.Students.Migrations
{
    /// <inheritdoc />
    public partial class Student_Key_Override : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppStudents");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppStudents");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppStudents");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppStudents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppStudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppStudents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppStudents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppStudents",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
