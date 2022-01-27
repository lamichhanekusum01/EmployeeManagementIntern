using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class AddedAttendenceDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time_out",
                table: "Attendences",
                newName: "Turn_out");

            migrationBuilder.RenameColumn(
                name: "Time_In",
                table: "Attendences",
                newName: "Turn_in");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "Attendences",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "Attendences");

            migrationBuilder.RenameColumn(
                name: "Turn_out",
                table: "Attendences",
                newName: "Time_out");

            migrationBuilder.RenameColumn(
                name: "Turn_in",
                table: "Attendences",
                newName: "Time_In");
        }
    }
}
