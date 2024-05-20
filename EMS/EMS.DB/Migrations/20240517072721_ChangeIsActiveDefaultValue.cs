using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIsActiveDefaultValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AlterColumn<bool>(
            //     name: "IsActive",
            //     table: "Employee",
            //     nullable: false,
            //     defaultValue: false,
            //     oldClrType: typeof(bool),
            //     oldType: "bit",
            //     oldDefaultValue: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
