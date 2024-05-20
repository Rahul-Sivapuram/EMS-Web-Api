using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddIsActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<bool>(
            // name: "IsActive",
            // table: "Employee",
            // type: "bit",
            // nullable: false,
            // defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
