using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddingSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Locations_LocationId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Departments_DepartmentId",
                table: "Roles");

            migrationBuilder.DropTable(
                name: "EmployeeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameColumn(
                name: "Dob",
                table: "Employee",
                newName: "DOB");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleId",
                table: "Employee",
                newName: "IX_Employee_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ProjectId",
                table: "Employee",
                newName: "IX_Employee_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ManagerId",
                table: "Employee",
                newName: "IX_Employee_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_LocationId",
                table: "Employee",
                newName: "IX_Employee_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Project",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Location",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uid",
                table: "Employee",
                type: "varchar(6)",
                unicode: false,
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employee",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employee",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Employee",
                type: "varchar(256)",
                unicode: false,
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Department",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Role__3214EC076D0FF33F",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Project__3214EC07C8DC1C01",
                table: "Project",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Location__3214EC079248A117",
                table: "Location",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Employee__3214EC07BBAA243F",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Departme__3214EC07E1001716",
                table: "Department",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__250375B14E91F0D3",
                table: "Employee",
                column: "MobileNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__7ED91ACE0A1D5596",
                table: "Employee",
                column: "EmailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__C5B69A4B5FD4F6C6",
                table: "Employee",
                column: "Uid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK__Employee__Depart__02FC7413",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Employee__Locati__01142BA1",
                table: "Employee",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Employee__Manage__00200768",
                table: "Employee",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Employee__Projec__03F0984C",
                table: "Employee",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Employee__RoleId__02084FDA",
                table: "Employee",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Role__Department__403A8C7D",
                table: "Roles",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Employee__Depart__02FC7413",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK__Employee__Locati__01142BA1",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK__Employee__Manage__00200768",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK__Employee__Projec__03F0984C",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK__Employee__RoleId__02084FDA",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK__Role__Department__403A8C7D",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Role__3214EC076D0FF33F",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Project__3214EC07C8DC1C01",
                table: "Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Location__3214EC079248A117",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Employee__3214EC07BBAA243F",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "UQ__Employee__250375B14E91F0D3",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "UQ__Employee__7ED91ACE0A1D5596",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "UQ__Employee__C5B69A4B5FD4F6C6",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Departme__3214EC07E1001716",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "DOB",
                table: "Employees",
                newName: "Dob");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_RoleId",
                table: "Employees",
                newName: "IX_Employees_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ProjectId",
                table: "Employees",
                newName: "IX_Employees_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ManagerId",
                table: "Employees",
                newName: "IX_Employees_ManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_LocationId",
                table: "Employees",
                newName: "IX_Employees_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldUnicode: false,
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Uid",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(6)",
                oldUnicode: false,
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldUnicode: false,
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldUnicode: false,
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmployeeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoiningDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<long>(type: "bigint", nullable: false),
                    Project = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDetails", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Locations_LocationId",
                table: "Employees",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Projects_ProjectId",
                table: "Employees",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Departments_DepartmentId",
                table: "Roles",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
