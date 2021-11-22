using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class ModelChangedGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Genders_Gender_Id",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Gender_Id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender_Id",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender_Id",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Gender_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Gender_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Gender_Id",
                table: "Employees",
                column: "Gender_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Genders_Gender_Id",
                table: "Employees",
                column: "Gender_Id",
                principalTable: "Genders",
                principalColumn: "Gender_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
