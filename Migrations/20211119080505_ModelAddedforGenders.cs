using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class ModelAddedforGenders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Gender_Gender_Id",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gender",
                table: "Gender");

            migrationBuilder.RenameTable(
                name: "Gender",
                newName: "Genders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genders",
                table: "Genders",
                column: "Gender_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Genders_Gender_Id",
                table: "Employees",
                column: "Gender_Id",
                principalTable: "Genders",
                principalColumn: "Gender_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Genders_Gender_Id",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genders",
                table: "Genders");

            migrationBuilder.RenameTable(
                name: "Genders",
                newName: "Gender");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gender",
                table: "Gender",
                column: "Gender_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Gender_Gender_Id",
                table: "Employees",
                column: "Gender_Id",
                principalTable: "Gender",
                principalColumn: "Gender_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
