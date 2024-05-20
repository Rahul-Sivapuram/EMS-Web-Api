using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.Sql(@"create view EmployeeDetails
            as
            SELECT 
                emp.Id, emp.Uid, emp.FirstName, emp.LastName, CONVERT(varchar(10),emp.Dob,23) as DOB, emp.EmailId, emp.MobileNumber,CONVERT(varchar(10),emp.JoiningDate,23) as JoiningDate, 
                Location.Name as Location, 
                Roles.Name as Role, 
                Department.Name as Department,
                CONCAT(manager.FirstName, ' ', manager.LastName) as Manager,
                Project.Name as Project  
            FROM 
                Employee as emp
            LEFT JOIN Employee as manager ON emp.ManagerId = manager.Id
            JOIN Location ON emp.LocationId = Location.Id
            JOIN Roles ON emp.RoleId = Roles.Id
            JOIN Department ON emp.DepartmentId = Department.Id
            JOIN Project ON emp.ProjectId = Project.Id;");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql(@"
                drop view EmployeeDetails;
                ");
        }
    }
}
