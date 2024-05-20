using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class passwordinemployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Password",
                table: "Employee",
                column: "Password",
                unique: true,
                filter: "[Password] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employee_Password",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employee");
        }
    }
}
