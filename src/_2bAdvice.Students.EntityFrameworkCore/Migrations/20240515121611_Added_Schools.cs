using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2bAdvice.Students.Migrations
{
    /// <inheritdoc />
    public partial class Added_Schools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SchoolId",
                table: "AppStudents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppSchools",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfSchool = table.Column<int>(type: "int", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSchools", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppStudents_SchoolId",
                table: "AppStudents",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppStudents_AppSchools_SchoolId",
                table: "AppStudents",
                column: "SchoolId",
                principalTable: "AppSchools",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppStudents_AppSchools_SchoolId",
                table: "AppStudents");

            migrationBuilder.DropTable(
                name: "AppSchools");

            migrationBuilder.DropIndex(
                name: "IX_AppStudents_SchoolId",
                table: "AppStudents");

            migrationBuilder.DropColumn(
                name: "SchoolId",
                table: "AppStudents");
        }
    }
}
