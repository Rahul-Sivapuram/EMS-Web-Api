using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.AddColumn<bool>(
        //     name: "IsActive",
        //     table: "Employee",
        //     type: "bit",
        //     nullable: false,
        //     defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ__Employee__250375B14E91F0D3",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Employee");

            migrationBuilder.AlterColumn<long>(
                name: "MobileNumber",
                table: "Employee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__250375B14E91F0D3",
                table: "Employee",
                column: "MobileNumber",
                unique: true);
        }
    }
}
