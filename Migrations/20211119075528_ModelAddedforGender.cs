using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class ModelAddedforGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender_Id",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Gender_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Gender_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Gender_Id",
                table: "Employees",
                column: "Gender_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Gender_Gender_Id",
                table: "Employees",
                column: "Gender_Id",
                principalTable: "Gender",
                principalColumn: "Gender_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Gender_Gender_Id",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Gender_Id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender_Id",
                table: "Employees");
        }
    }
}
