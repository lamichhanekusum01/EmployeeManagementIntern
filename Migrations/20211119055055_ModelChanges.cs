using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class ModelChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Attendences_Attendence_Id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Attendence_Id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Attendences_Employee_Id",
                table: "Attendences");

            migrationBuilder.AlterColumn<double>(
                name: "Phone",
                table: "Employees",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DesignationName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time_In",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Time_out",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_Employee_Id",
                table: "Attendences",
                column: "Employee_Id",
                unique: true,
                filter: "[Employee_Id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Attendences_Employee_Id",
                table: "Attendences");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DesignationName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Time_In",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Time_out",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Attendence_Id",
                table: "Employees",
                column: "Attendence_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Attendences_Employee_Id",
                table: "Attendences",
                column: "Employee_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Attendences_Attendence_Id",
                table: "Employees",
                column: "Attendence_Id",
                principalTable: "Attendences",
                principalColumn: "Attendence_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
