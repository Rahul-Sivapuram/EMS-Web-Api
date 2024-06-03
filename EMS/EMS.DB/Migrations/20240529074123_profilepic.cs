using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class profilepic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
            
            migrationBuilder.Sql(@"drop view EmployeeDetails"); 

               migrationBuilder.Sql(@"
                CREATE VIEW EmployeeDetails AS
                SELECT
                emp.Id,
                emp.Uid,
                emp.FirstName,
                emp.LastName,
                CONVERT(varchar(10), emp.Dob, 23) AS DOB,
                emp.EmailId,
                emp.MobileNumber,
                CONVERT(varchar(10), emp.JoiningDate, 23) AS JoiningDate,
                Location.Name AS Location,
                Roles.Name AS Role,
                Department.Name AS Department,
                CONCAT(manager.FirstName, ' ', manager.LastName) AS Manager,
                Project.Name AS Project,
                emp.IsActive,
                Modes.Name as ModelStatus,
                emp.ProfilePic
                FROM
                Employee AS emp
                LEFT JOIN Employee AS manager ON emp.ManagerId = manager.Id
                JOIN Location ON emp.LocationId = Location.Id
                JOIN Roles ON emp.RoleId = Roles.Id
                JOIN Department ON emp.DepartmentId = Department.Id
                JOIN Project ON emp.ProjectId = Project.Id
                Join Modes on emp.ModeId = Modes.Id;
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "Employee");
        }
    }
}
