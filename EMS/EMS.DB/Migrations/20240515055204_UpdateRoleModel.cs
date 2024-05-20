using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoleModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Roles",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_EmployeeId",
                table: "Roles",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LocationId",
                table: "Roles",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK__Role__Employee",
                table: "Roles",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Role__Location",
                table: "Roles",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Role__Employee",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK__Role__Location",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_EmployeeId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_LocationId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Roles");
        }
    }
}
