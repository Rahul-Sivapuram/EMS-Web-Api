using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EMS.DB.Migrations
{
    /// <inheritdoc />
    public partial class createtablesinnewdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "UIUX" },
                    { 2, "PRODUCT ENGINEERING" },
                    { 3, "QUALITY ANALYST" },
                    { 4, "IT" }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hyderabad" },
                    { 2, "Mumbai" },
                    { 3, "Bangalore" },
                    { 4, "Delhi" }
                });

          

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AMAZON" },
                    { 2, "MYNTRA" },
                    { 3, "CISCO" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DepartmentId", "Description", "EmployeeId", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "uiux designer", null, null, "UIUX DESIGNER" },
                    { 2, 2, null, null, null, "FULL STACK DEVELOPER" },
                    { 3, 4, "backend developer", null, null, "BACKEND DEVELOPER" },
                    { 4, 4, null, null, null, "ASSISTANT BACKEND DEVELOPER" },
                    { 5, 1, null, null, null, "FRONT END DEVELOPER" },
                    { 6, 4, null, null, null, "CUSTOMER SERVICE MANAGER" },
                    { 7, 4, null, null, null, "CUSTOMER SUPPORT" },
                    { 8, 4, null, null, null, "SOLUTION ARCHITECT" },
                    { 9, 4, null, null, null, "DOT NET DEVELOPER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Location",
                keyColumn: "Id",
                keyValue: 4);

         
            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 4);

          
        }
    }
}
