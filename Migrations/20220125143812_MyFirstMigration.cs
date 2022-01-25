using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation_Name",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EId",
                table: "Leaves",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Leaves",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Leave_Id",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Leave_Id",
                table: "AspNetUsers",
                column: "Leave_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Leaves_Leave_Id",
                table: "AspNetUsers",
                column: "Leave_Id",
                principalTable: "Leaves",
                principalColumn: "Leave_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Leaves_Leave_Id",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Leave_Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Designation_Name",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "EId",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Leave_Id",
                table: "AspNetUsers");
        }
    }
}
