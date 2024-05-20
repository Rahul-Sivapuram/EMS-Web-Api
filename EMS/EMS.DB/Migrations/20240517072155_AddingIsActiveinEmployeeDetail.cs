using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsActiveinEmployeeDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql(@"DROP VIEW IF EXISTS EmployeeDetails;");

            // Create the new view with the updated definition
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
                emp.IsActive
            FROM 
                Employee AS emp
            LEFT JOIN Employee AS manager ON emp.ManagerId = manager.Id
            JOIN Location ON emp.LocationId = Location.Id
            JOIN Roles ON emp.RoleId = Roles.Id
            JOIN Department ON emp.DepartmentId = Department.Id
            JOIN Project ON emp.ProjectId = Project.Id;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
