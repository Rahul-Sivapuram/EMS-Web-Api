using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class modestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE TABLE Modes(
            Id INT NOT NULL PRIMARY KEY,
            Name VARCHAR(70) NOT NULL
            );");

            migrationBuilder.InsertData(
               table: "Modes",
               columns: new[] { "Id", "Name" },
               values: new object[,]
               {
                    { 1, "Active" },
                    { 2, "Do Not Disturb" },
                    { 3, "Sleep" }
               });

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
                Modes.Name as ModelStatus
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

        }
    }
}
